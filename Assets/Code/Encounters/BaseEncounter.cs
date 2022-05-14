using System.Threading;
using Code.StressSystem;
using UnityEngine;

namespace Code.Encounters
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseEncounter : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioSource;
        public bool IsEnabled => _isEnabled;
        
        public EncounterType Type;

        protected CancellationTokenSource _token;
        private EncounterData _encounterData;
        private float _timeToActive;
        private float _lastDeactivatedTime;
        private bool _isActive;
        private bool _isEnabled;

        protected virtual void Awake()
        {
            _encounterData = StressManager.Instance.EncounterTypeToData[Type];
        }
        
        protected virtual void Enable()
        {
            Debug.Log($"Enabled {name}");
            if (_encounterData.onEnableAudio != null)
            {
                audioSource.clip = _encounterData.onEnableAudio;
                audioSource.Play();
            }
        }
        protected virtual void Activate()
        {
            if (_encounterData.onActiveAudio != null)
            {
                audioSource.clip = _encounterData.onActiveAudio;
                audioSource.Play();
            }
        }
        protected virtual void Disable()
        {
            Debug.Log($"Disabled {name}");
            if (_encounterData.onDisableAudio != null)
            {
                audioSource.clip = _encounterData.onDisableAudio;
                audioSource.Play();
            }
        }
        
        public float GetStress()
        {
            if (_isActive)
            {
                return _encounterData.stressGeneratedPerTickActive;
            }

            _timeToActive--;
            if (_timeToActive <= 0)
            {
                _isActive = true;
                TryCancelAndDispose();
                Activate();
            }
            return _encounterData.stressGeneratedPerTickInactive;
        }
        
        public void TryEnable()
        {
            if (_encounterData.ticksToSpawn <= StressManager.Instance.TimePassed &&  StressManager.Instance.CanSpawn(_encounterData.spawnCost, _lastDeactivatedTime))
            {
                _isEnabled = true;
                _timeToActive = _encounterData.ticksToActivate;
                
                _token = new CancellationTokenSource();
                Enable();
            }
        }
        
        public void OnMouseDown()
        {
            if (_isActive || _isEnabled)
            {
                _lastDeactivatedTime = StressManager.Instance.TimePassed;
                _isActive = false;
                _isEnabled = false;
                Disable();
                TryCancelAndDispose();
            }
        }

        private void TryCancelAndDispose()
        {
            if (_token != null)
            {
                _token.Cancel();
                _token.Dispose();
                _token = null;
            }
        }
    }
}
