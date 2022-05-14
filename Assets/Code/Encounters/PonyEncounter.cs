using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class PonyEncounter : BaseEncounter
    {
        [SerializeField] private Transform pony;
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeStrength;

        protected override void Enable()
        {
            base.Enable();
            pony.DOShakeRotation(shakeDuration, shakeStrength);
        }
        protected override void Activate()
        {
            base.Activate();
            pony.DOShakeRotation(shakeDuration, shakeStrength);
        }
        protected override void Disable()
        {
            base.Disable();
        }
    }
}
