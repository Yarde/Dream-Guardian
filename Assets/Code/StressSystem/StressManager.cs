using System;
using System.Collections.Generic;
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

        public Dictionary<EncounterType, EncounterData> EncounterTypeToData;

        public Action OnClockTick { get; set; }
        public Action OnStressUpdated { get; set; }
        
        public StressManager()
        {
            _encountersData = Resources.Load<EncountersData>("Encounters/EncountersData");
            _difficultyData = Resources.Load<DifficultyData>("Difficulty/Medium");

            EncounterTypeToData = new Dictionary<EncounterType, EncounterData>();
            foreach (var encounter in _encountersData.encounters)
            {
                EncounterTypeToData.Add(encounter.type, encounter);
            }
        }
        
        public float StressMeter { get; private set; }
        public float StressRatio => StressMeter / _difficultyData.maxStress;

        public float TimePassed { get; private set; } = 0;
        public int TimeIncrement => _difficultyData.ticksTimeMilliseconds;

        public Vector3 CutoffSize => Vector3.one * (_difficultyData.cutoffSize - _difficultyData.cutoffStressDecrease * StressMeter);
        public Color BlendColor => _difficultyData.blendColor;
        public float NewEncounterProbability => 1;

        public void ClockTick()
        {
            TimePassed++;
            StressMeter = Mathf.Max(StressMeter - _difficultyData.stressDecrementPerTick, 0);
            
            Debug.Log($"Update Stress Manager {StressMeter}");
            OnClockTick?.Invoke();
        }
        
        public void AddStress(float delta)
        {
            StressMeter += delta;

            if (StressRatio >= 1f)
            {
                Debug.LogError("You lost!");
            }
            
            OnStressUpdated?.Invoke();
        }
    }

}
