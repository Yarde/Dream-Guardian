using Code.StressSystem;

namespace Code.Encounters
{
    public class LightEncounter : BaseEncounter
    {

        public override float GetStress()
        {
            EncounterData encounterData = StressManager.Instance.EncounterTypeToData[Type];

            if (IsActive)
            {
                return encounterData.stressGeneratedActive;
            }
            return encounterData.stressGeneratedInactive;
        }
    }
}
