using UnityEngine;

namespace Code.StressSystem
{
    [CreateAssetMenu(menuName = "Encounters/EncountersData")]
    public class EncountersData : ScriptableObject
    {
        public EncounterData[] encounters;
    }

}
