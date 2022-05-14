using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        private float _spawnProbability = 160;

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

            RenderSettings.ambientLight = _difficultyData.blendColor;
        }
        
        public float StressMeter { get; private set; }
        public float StressRatio => StressMeter / _difficultyData.maxStress;

        public float TimePassed { get; private set; } = 0;
        public int TimeIncrement => _difficultyData.ticksTimeMilliseconds;
        
        public Color BlendColor => _difficultyData.blendColor;
        public bool CanSpawn(float spawnCost)
        {
            float random = Random.Range(0f, 100f);
            float difference = _spawnProbability - spawnCost;

            if (random < difference)
            {
                _spawnProbability -= spawnCost;
                return true;
            }

            return false;
        }

        public void ClockTick()
        {
            TimePassed++;
            StressMeter = Mathf.Max(StressMeter - _difficultyData.stressDecrementPerTick, 0);
            _spawnProbability += _difficultyData.spawnProbabilityIncrementPerTick + TimePassed * _difficultyData.spawnProbabilityMultiplier;
            
            Debug.Log($"StressMeter: {StressMeter}, TimePassed: {TimePassed}, Spawn Probability: {_spawnProbability}");
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
