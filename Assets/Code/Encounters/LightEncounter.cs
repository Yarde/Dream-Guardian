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
            while (!_token.IsCancellationRequested)
            {
                await lightBulb.DOIntensity(flickerIntensityMax, flickerTime).WithCancellation(_token.Token);
                await lightBulb.DOIntensity(flickerIntensityMin, flickerTime).WithCancellation(_token.Token);
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
