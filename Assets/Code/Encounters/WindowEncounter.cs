using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class WindowEncounter : BaseEncounter
    {
        [SerializeField] private Transform window;
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeStrength;
        [SerializeField] private float closeIntensity;
        [SerializeField] private float openIntensity;
        [SerializeField] private Light outsideLight;

        protected override void Enable()
        {
            base.Enable();
            window.DOShakePosition(shakeDuration, shakeStrength).WithCancellation(_token.Token);
            outsideLight.DOIntensity(openIntensity, shakeDuration).WithCancellation(_token.Token);
        }
        protected override void Activate()
        {
            base.Activate();
        }
        protected override void Disable()
        {
            base.Disable();
            outsideLight.intensity = closeIntensity;
        }
    }
}
