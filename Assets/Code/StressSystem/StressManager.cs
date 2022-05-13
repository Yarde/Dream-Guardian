using System;
using UnityEngine;

namespace Code.StressSystem
{
    public class StressManager
    {
        private static StressManager _instance;
        public static StressManager Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new StressManager();
                }
                return _instance;
            }
            
        }
        
        private EncountersData _encountersData;
        private DifficultyData _difficultyData;
        
        public Action OnStressUpdate { get; set; }
        
        public StressManager()
        {
            _encountersData = Resources.Load<EncountersData>("Encounters/EncountersData");
            _difficultyData = Resources.Load<DifficultyData>("Difficulty/Medium");
        }
        
        public float StressMeter { get; private set; }
        
        public float TimePassed { get; private set; }
        public int TimeIncrement => _difficultyData.timeIncrement;

        public Vector3 CutoffSize => Vector3.one * (_difficultyData.cutoffSize - _difficultyData.cutoffStressDecrease * StressMeter);
        public Color BlendColor => _difficultyData.blendColor;
        
        public void CalculateStress()
        {
            StressMeter = Mathf.Max(StressMeter - _difficultyData.stressDecrement, 0);
            
            Debug.Log($"Update Stress Manager {StressMeter}");
            
            OnStressUpdate?.Invoke();
        }
    }

}
