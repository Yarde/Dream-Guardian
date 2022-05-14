using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class PonyEncounter : BaseEncounter
    {
        [SerializeField] private SpriteRenderer pony;
        [SerializeField] private SpriteRenderer spookyPony;
        [SerializeField] private float shakeDuration;
        [SerializeField] private float shakeStrength;
        [SerializeField] private float strongShakeDuration;
        [SerializeField] private float strongShakeStrength;
        
        protected override void Enable()
        {
            base.Enable();
            pony.transform.DOShakeRotation(shakeDuration, new Vector3(0, 0, shakeStrength)).WithCancellation(_token.Token);
        }
        protected override void Activate()
        {
            base.Activate();
            spookyPony.gameObject.SetActive(true);
            spookyPony.DOFade(0f, 0f);
            spookyPony.DOFade(1f, 0.5f);
            pony.gameObject.SetActive(false);
            spookyPony.transform.DOShakeRotation(strongShakeDuration, new Vector3(0, 0, strongShakeStrength)).WithCancellation(_token.Token);
        }
        protected override void Disable()
        {
            base.Disable();
            spookyPony.gameObject.SetActive(false);
            spookyPony.DOFade(0f, 0f);
            pony.gameObject.SetActive(true);
            pony.transform.DOLocalRotate(Vector3.zero, 0.1f).WithCancellation(_token.Token);
        }
    }
}
