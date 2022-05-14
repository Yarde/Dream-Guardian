using UnityEngine;

namespace Code.Encounters
{
    public class RugEncounter : BaseEncounter
    {
        /*[SerializeField] private Transform rug;
        [SerializeField] private Transform hand;
        [SerializeField] private Vector3 rugStartPosition;
        [SerializeField] private Vector3 rugEndPosition;
        [SerializeField] private float rugMoveDuration;
        [SerializeField] private Vector3 handStartPosition;
        [SerializeField] private Vector3 handEndPosition;
        [SerializeField] private float handMoveDuration;*/
        
        [SerializeField] private GameObject rug;
        [SerializeField] private GameObject rugWithHand;
        [SerializeField] private GameObject handOnBlanket;

        protected override void Enable()
        {
            base.Enable();
            rugWithHand.SetActive(true);
        }
        /*private async UniTask Animate()
        {
            rug.DOLocalMove(rugEndPosition, rugMoveDuration);
            await UniTask.Delay((int)(rugMoveDuration * 1000));
            hand.DOLocalMove(handEndPosition, handMoveDuration);
        }*/
        
        protected override void Activate()
        {
            base.Activate();
            rugWithHand.SetActive(false);
            handOnBlanket.SetActive(true);
        }
        
        protected override void Disable()
        {
            base.Disable();
            rugWithHand.SetActive(false);
            handOnBlanket.SetActive(false);
            rug.SetActive(true);
        }
    }
}
