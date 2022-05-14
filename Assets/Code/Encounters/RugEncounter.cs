using UnityEngine;

namespace Code.Encounters
{
    public class RugEncounter : BaseEncounter
    {
        [SerializeField] private GameObject rug;
        [SerializeField] private GameObject rugWithHand;
        [SerializeField] private GameObject handOnBlanket;

        protected override void Enable()
        {
            base.Enable();
            rugWithHand.SetActive(true);
        }

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
