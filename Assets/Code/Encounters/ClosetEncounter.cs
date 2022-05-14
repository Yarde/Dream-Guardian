using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class ClosetEncounter : BaseEncounter
    {
        [SerializeField] private Transform closetDoor;
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeStrength;
        [SerializeField] private GameObject spookyEyes;

        protected override void Enable()
        {
            base.Enable();
            closetDoor.DOShakePosition(shakeDuration, shakeStrength);
        }
        protected override void Activate()
        {
            base.Activate();
            spookyEyes.SetActive(true);
        }
        protected override void Disable()
        {
            base.Disable();
            spookyEyes.SetActive(true);
        }
    }
}
