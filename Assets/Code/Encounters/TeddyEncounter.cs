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

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = teddy.localPosition;
        }

        protected override void Enable()
        {
            base.Enable();
            spookyEyes.SetActive(true);
            if (_token != null && !_token.IsCancellationRequested)
            {
                teddy.DOShakeRotation(shakeDuration, new Vector3(0, 0, shakeStrength)).WithCancellation(_token.Token);
            }
        }
        protected override void Activate()
        {
            base.Activate();
            if (_token != null && !_token.IsCancellationRequested)
            {
                teddy.DOShakePosition(shakeDuration, new Vector3(shakeStrength, shakeStrength, 0)).WithCancellation(_token.Token);
            }
        }
        protected override void Disable()
        {
            base.Disable();
            teddy.DOLocalMove(_startPosition, 0.2f);
            spookyEyes.SetActive(false);
        }
    }
}
