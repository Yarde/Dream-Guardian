using UnityEngine;

namespace Code.StressSystem
{
    [CreateAssetMenu(menuName = "Encounters/Encounter")]
    public class Encounter : ScriptableObject
    {
        public EncounterType type;
        public float timeToSpawn;
        public float timeLimit;
        public float stressGeneratedInactive;
        public float stressGeneratedActive;
    }
}
