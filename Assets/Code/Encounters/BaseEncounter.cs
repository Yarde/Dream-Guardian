using System.Threading;
using Code.StressSystem;
using UnityEngine;

namespace Code.Encounters
{
    [RequireComponent(typeof(Collider))]
    public abstract class BaseEncounter : MonoBehaviour
    {
        [SerializeField] protected AudioSource audio;
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
            if (_encounterData.onEnableAudio != null)
            {
                audio.clip = _encounterData.onEnableAudio;
                audio.Play();
            }
        }
        protected virtual void Activate()
        {
            if (_encounterData.onActiveAudio != null)
            {
                audio.clip = _encounterData.onActiveAudio;
                audio.Play();
            }
        }
        protected virtual void Disable()
        {
            if (_encounterData.onDisableAudio != null)
            {
                audio.clip = _encounterData.onDisableAudio;
                audio.Play();
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
            _lastDeactivatedTime = StressManager.Instance.TimePassed;
            _isActive = false;
            _isEnabled = false;
            Disable();
            TryCancelAndDispose();
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
