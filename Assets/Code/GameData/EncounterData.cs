using UnityEngine;

namespace Code.StressSystem
{
    [CreateAssetMenu(menuName = "Encounters/EncounterData")]
    public class EncounterData : ScriptableObject
    {
        public EncounterType type;
        public float timeToSpawn;
        public float timeLimit;
        public float stressGeneratedInactive;
        public float stressGeneratedActive;
    }
}
