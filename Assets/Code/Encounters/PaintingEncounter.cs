using UnityEngine;

namespace Code.Encounters
{
    public class PaintingEncounter : BaseEncounter
    {
        [SerializeField] private GameObject silhouette;
        [SerializeField] private GameObject head;

        protected override void Enable()
        {
            base.Enable();
            silhouette.SetActive(true);
        }
        protected override void Activate()
        {
            base.Activate();
            head.SetActive(true);
        }
        protected override void Disable()
        {
            base.Disable();
            silhouette.SetActive(false);
            head.SetActive(false);
        }
    }
}
