using DG.Tweening;
using UnityEngine;

namespace Code.Encounters
{
    public class DoorEncounter : BaseEncounter
    {
        [SerializeField] private GameObject closedDoor;
        [SerializeField] private SpriteRenderer ajarDoor;
        [SerializeField] private SpriteRenderer openDoor;

        protected override void Enable()
        {
            base.Enable();
            ajarDoor.gameObject.SetActive(true);
            ajarDoor.DOFade(0f, 0f);
            ajarDoor.DOFade(1f, 0.5f);
        }
        protected override void Activate()
        {
            base.Activate();
            openDoor.gameObject.SetActive(true);
            openDoor.DOFade(0f, 0f);
            openDoor.DOFade(1f, 0.5f);
        }
        protected override void Disable()
        {
            base.Disable();
            ajarDoor.DOFade(0f, 0f);
            openDoor.DOFade(0f, 0f);
            closedDoor.SetActive(true);
            openDoor.gameObject.SetActive(false);
            ajarDoor.gameObject.SetActive(false);
        }
    }
}
