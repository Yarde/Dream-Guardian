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
            closedDoor.SetActive(false);
        }
        protected override void Activate()
        {
            base.Activate();
            openDoor.gameObject.SetActive(true);
            ajarDoor.gameObject.SetActive(false);
        }
        protected override void Disable()
        {
            base.Disable();
            closedDoor.SetActive(true);
            openDoor.gameObject.SetActive(false);
            ajarDoor.gameObject.SetActive(false);
        }
    }
}
