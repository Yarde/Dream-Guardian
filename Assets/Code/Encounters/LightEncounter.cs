using System.Threading;
using Code.StressSystem;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class LightEncounter : BaseEncounter
    {
        [SerializeField] private float flickerTime;
        [SerializeField] private float flickerIntensityMin;
        [SerializeField] private float flickerIntensityMax;
        [SerializeField] private GameObject stateOn;
        [SerializeField] private Light lightBulb;

        private CancellationTokenSource _token;

        public override float GetStress()
        {
            if (IsActive)
            {
                return _encounterData.stressGeneratedPerTickActive;
            }

            _timeToActive--;
            if (_timeToActive <= 0)
            {
                IsActive = true;
                TryCancelAndDispose();
            }
            return _encounterData.stressGeneratedPerTickInactive;
        }
        
        public override void TryEnable()
        {
            if (_encounterData.ticksToSpawn <= StressManager.Instance.TimePassed &&  StressManager.Instance.CanSpawn(_encounterData.spawnCost))
            {
                IsEnabled = true;
                _timeToActive = _encounterData.ticksToActivate;
                
                stateOn.SetActive(true);
                _token = new CancellationTokenSource();
                StartFlickering().Forget();
            }
        }
        private async UniTask StartFlickering()
        {
            lightBulb.DOIntensity(flickerIntensityMax, flickerTime);
            await UniTask.Delay((int)(flickerTime * 1000));
            
            while (_token != null && !_token.IsCancellationRequested)
            {
                lightBulb.DOIntensity(flickerIntensityMin, flickerTime);
                await UniTask.Delay((int)(flickerTime * 1000));
                lightBulb.DOIntensity(flickerIntensityMax, flickerTime);
                await UniTask.Delay((int)(flickerTime * 1000));
            }
        }
        public void OnMouseDown()
        {
            _lastDeactivatedTime = StressManager.Instance.TimePassed;
            IsActive = false;
            IsEnabled = false;
            stateOn.SetActive(false);
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
