using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class PonyEncounter : BaseEncounter
    {
        [SerializeField] private Transform pony;
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeStrength;
        [SerializeField] private float strongShakeDuration;
        [SerializeField] private float strongShakeStrength;
        
        protected override void Enable()
        {
            base.Enable();
            pony.DOShakeRotation(shakeDuration, new Vector3(0, 0, shakeStrength)).WithCancellation(_token.Token);
        }
        protected override void Activate()
        {
            base.Activate();
            pony.DOShakeRotation(strongShakeDuration, new Vector3(0, 0, strongShakeStrength)).WithCancellation(_token.Token);
        }
        protected override void Disable()
        {
            base.Disable();
            pony.DOLocalRotate(Vector3.zero, 0.1f).WithCancellation(_token.Token);
        }
    }
}
