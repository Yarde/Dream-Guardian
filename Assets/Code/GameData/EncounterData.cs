using UnityEngine;

namespace Code.StressSystem
{
    [CreateAssetMenu(menuName = "Encounters/EncounterData")]
    public class EncounterData : ScriptableObject
    {
        public EncounterType type;
        public float ticksToSpawn;
        public float ticksToActivate;
        public float stressGeneratedPerTickInactive;
        public float stressGeneratedPerTickActive;
        public float spawnCost;
    }
}
