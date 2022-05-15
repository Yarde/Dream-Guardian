using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class RugEncounter : BaseEncounter
    {
        [SerializeField] private GameObject rug;
        [SerializeField] private SpriteRenderer rugWithHand;
        [SerializeField] private GameObject handOnBlanket;

        protected override void Enable()
        {
            base.Enable();
            rugWithHand.gameObject.SetActive(true);
            rugWithHand.DOFade(0f, 0f);
            rugWithHand.DOFade(1f, 0.2f);
            rug.SetActive(false);
        }

        protected override void Activate()
        {
            base.Activate();
            rugWithHand.gameObject.SetActive(false);
            handOnBlanket.SetActive(true);
        }
        
        protected override void Disable()
        {
            base.Disable();
            rugWithHand.DOFade(0f, 0f);
            rugWithHand.gameObject.SetActive(false);
            handOnBlanket.SetActive(false);
            rug.SetActive(true);
        }
    }
}
