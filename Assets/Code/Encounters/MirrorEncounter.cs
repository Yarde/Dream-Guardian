using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class MirrorEncounter : BaseEncounter
    {
        [SerializeField] private SpriteRenderer silhouette;
        [SerializeField] private SpriteRenderer leg;

        protected override void Enable()
        {
            base.Enable();
            silhouette.gameObject.SetActive(true);
            silhouette.DOFade(0f, 0f);
            silhouette.DOFade(1f, 0.5f);
        }
        protected override void Activate()
        {
            base.Activate();
            leg.gameObject.SetActive(true);
            leg.DOFade(0f, 0f);
            leg.DOFade(1f, 0.5f);
        }
        protected override void Disable()
        {
            base.Disable();
            silhouette.gameObject.SetActive(true);
            leg.gameObject.SetActive(true);
            silhouette.DOFade(0f, 0f);
            leg.DOFade(0f, 0f);
        }
    }
}
