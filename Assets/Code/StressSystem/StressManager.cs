using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.StressSystem
{
    public class StressManager
    {
        public static StressManager Instance { get; set; }

        private DifficultyData _difficultyData;
        private float _spawnProbability = 160;

        public Dictionary<EncounterType, EncounterData> EncounterTypeToData;

        public Action OnClockTick { get; set; }
        public Action OnStressUpdated { get; set; }
        public Action OnWin { get; set; }
        public Action OnLost { get; set; }
        
        public StressManager(string setting)
        {
            _difficultyData = Resources.Load<DifficultyData>($"Difficulty/{setting}");

            EncounterTypeToData = new Dictionary<EncounterType, EncounterData>();
            foreach (var encounter in _difficultyData.encounters)
            {
                EncounterTypeToData.Add(encounter.type, encounter);
            }
        }

        public Color AmbientLight => _difficultyData.blendColor;
        
        public float StressMeter { get; private set; }
        public float StressRatio => StressMeter / _difficultyData.maxStress;

        public float TimePassed { get; private set; } = 0;
        public int TimeIncrement => _difficultyData.ticksTimeMilliseconds;
        
        public Color BlendColor => _difficultyData.blendColor;

        public void Restart()
        {
            Instance = null;
        }
        
        public bool CanSpawn(float spawnCost, float lastDeactivatedTime)
        {
            float random = Random.Range(0f, 100f);
            float difference = _spawnProbability - spawnCost;

            if (random < difference + TimePassed - lastDeactivatedTime)
            {
                _spawnProbability -= spawnCost;
                return true;
            }

            return false;
        }

        public void ClockTick()
        {
            TimePassed++;
            if (TimePassed >= _difficultyData.ticksToWin)
            {
                Debug.LogError("You won!");
                OnWin?.Invoke();
                return;
            }
            
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
                OnLost?.Invoke();
            }
            
            OnStressUpdated?.Invoke();
        }
    }

}
