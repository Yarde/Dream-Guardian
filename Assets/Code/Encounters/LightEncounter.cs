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
        [SerializeField] private Light lightBulb;

        protected override void Enable()
        {
            base.Enable();
            StartFlickering().Forget();
        }
        protected override void Activate()
        {
            base.Activate();
        }
        protected override void Disable()
        {
            base.Disable();
            lightBulb.intensity = 0;
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

            if (IsEnabled)
            {
                lightBulb.intensity = flickerIntensityMax;
            }
            else
            {
                lightBulb.intensity = 0;
            }
        }
    }
}
