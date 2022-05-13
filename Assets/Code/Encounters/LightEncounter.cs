using System;
using Code.StressSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Encounters
{
    public class LightEncounter : BaseEncounter
    {
        [SerializeField] private Image image;

        public override float GetStress()
        {
            if (IsActive)
            {
                return _encounterData.stressGeneratedActive;
            }

            _timeToActive--;
            if (_timeToActive <= 0)
            {
                IsActive = true;
                image.color = Color.blue;
            }
            return _encounterData.stressGeneratedInactive;
        }
        
        public override void TryEnable()
        {
            if (_encounterData.timeToSpawn <= StressManager.Instance.TimePassed)
            {
                IsEnabled = true;
                _timeToActive = _encounterData.timeLimit;
                
                image.color = Color.cyan;
            }
        }
    }
}
