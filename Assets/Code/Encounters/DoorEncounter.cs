using UnityEngine;

namespace Code.Encounters
{
    public class DoorEncounter : BaseEncounter
    {
        [SerializeField] private GameObject closedDoor;
        [SerializeField] private GameObject ajarDoor;
        [SerializeField] private GameObject openDoor;

        protected override void Enable()
        {
            base.Enable();
            ajarDoor.SetActive(true);
            openDoor.SetActive(false);
            closedDoor.SetActive(false);
        }
        protected override void Activate()
        {
            base.Activate();
            openDoor.SetActive(true);
            ajarDoor.SetActive(false);
            closedDoor.SetActive(false);
        }
        protected override void Disable()
        {
            base.Disable();
            closedDoor.SetActive(true);
            openDoor.SetActive(false);
            ajarDoor.SetActive(false);
        }
    }
}
