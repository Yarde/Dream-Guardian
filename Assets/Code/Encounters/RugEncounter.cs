using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class RugEncounter : BaseEncounter
    {
        [SerializeField] private Transform rug;
        [SerializeField] private Transform hand;
        [SerializeField] private Vector3 rugStartPosition;
        [SerializeField] private Vector3 rugEndPosition;
        [SerializeField] private float rugMoveDuration;
        [SerializeField] private Vector3 handStartPosition;
        [SerializeField] private Vector3 handEndPosition;
        [SerializeField] private float handMoveDuration;

        protected override void Enable()
        {
            base.Enable();
            Animate().Forget();
        }
        private async UniTask Animate()
        {
            rug.DOLocalMove(rugEndPosition, rugMoveDuration);
            await UniTask.Delay((int)(rugMoveDuration * 1000));
            hand.DOLocalMove(handEndPosition, handMoveDuration);
        }
        
        protected override void Activate()
        {
            base.Activate();
        }
        
        protected override void Disable()
        {
            base.Disable();
            rug.transform.position = rugStartPosition;
            hand.transform.position = handStartPosition;
        }
    }
}
