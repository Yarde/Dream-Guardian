using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class TeddyEncounter : BaseEncounter
    {
        [SerializeField] private Transform teddy;
        [SerializeField] private GameObject spookyEyes;
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeStrength;

        protected override void Enable()
        {
            base.Enable();
            teddy.DOShakeRotation(shakeDuration, shakeStrength).WithCancellation(_token.Token);
        }
        protected override void Activate()
        {
            base.Activate();
            spookyEyes.SetActive(true);
            teddy.DOShakeRotation(shakeDuration, shakeStrength).WithCancellation(_token.Token);
        }
        protected override void Disable()
        {
            base.Disable();
            spookyEyes.SetActive(false);
        }
    }
}
