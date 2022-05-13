using Code.StressSystem;
using UnityEngine;

namespace Code.Encounters
{
    public abstract class BaseEncounter : MonoBehaviour
    {
        public bool IsEnabled;
        public bool IsActive;
        public EncounterType Type;
        public abstract float GetStress();
    }
}
