using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class WindowEncounter : BaseEncounter
    {
        [SerializeField] private float duration;
        [SerializeField] private float closeIntensity;
        [SerializeField] private float ajarIntensity;
        [SerializeField] private float openIntensity;
        [SerializeField] private Light outsideLight;
        
        [SerializeField] private Color colorNormal;
        [SerializeField] private Color colorRed;
        
        [SerializeField] private SpriteRenderer ajar;
        [SerializeField] private SpriteRenderer open;

        protected override void Enable()
        {
            base.Enable();
            ajar.gameObject.SetActive(true);
            ajar.DOFade(0f, 0f);
            ajar.DOFade(1f, 0.2f);
            outsideLight.DOIntensity(ajarIntensity, duration).WithCancellation(_token.Token);
        }
        protected override void Activate()
        {
            base.Activate();
            open.gameObject.SetActive(true);
            open.DOFade(0f, 0f);
            open.DOFade(1f, 0.2f);
            outsideLight.DOIntensity(openIntensity, duration).WithCancellation(_token.Token);
            outsideLight.color = colorRed;
        }
        protected override void Disable()
        {
            base.Disable();
            ajar.DOFade(0f, 0f);
            open.DOFade(0f, 0f);
            outsideLight.intensity = closeIntensity;
            outsideLight.color = colorNormal;
            ajar.gameObject.SetActive(false);
            open.gameObject.SetActive(false);
        }
    }
}
