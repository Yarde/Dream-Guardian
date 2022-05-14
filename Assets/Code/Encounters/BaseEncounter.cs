using System;
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
        public abstract void TryEnable();

        protected EncounterData _encounterData;
        protected float _timeToActive;
        
        private void Awake()
        {
            _encounterData = StressManager.Instance.EncounterTypeToData[Type];
        }
    }
}
