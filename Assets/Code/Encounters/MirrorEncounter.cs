using UnityEngine;

namespace Code.Encounters
{
    public class MirrorEncounter : BaseEncounter
    {
        [SerializeField] private GameObject silhouette;
        [SerializeField] private GameObject leg;

        protected override void Enable()
        {
            base.Enable();
            silhouette.SetActive(true);
        }
        protected override void Activate()
        {
            base.Activate();
            leg.SetActive(true);
        }
        protected override void Disable()
        {
            base.Disable();
            silhouette.SetActive(false);
            leg.SetActive(false);
        }
    }
}
