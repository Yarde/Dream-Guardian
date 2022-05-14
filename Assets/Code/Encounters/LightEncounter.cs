using Code.StressSystem;
using UnityEngine;

namespace Code.Encounters
{
    public class LightEncounter : BaseEncounter
    {
        [SerializeField] private SpriteRenderer image;

        public override float GetStress()
        {
            if (IsActive)
            {
                return _encounterData.stressGeneratedPerTickActive;
            }

            _timeToActive--;
            if (_timeToActive <= 0)
            {
                IsActive = true;
                image.color = Color.blue;
            }
            return _encounterData.stressGeneratedPerTickInactive;
        }
        
        public override void TryEnable()
        {
            if (_encounterData.ticksToSpawn <= StressManager.Instance.TimePassed)
            {
                IsEnabled = true;
                _timeToActive = _encounterData.ticksToActivate;
                
                image.color = Color.cyan;
            }
        }
        public void OnMouseDown()
        {
            _lastDeactivatedTime = StressManager.Instance.TimePassed;
            IsActive = false;
            IsEnabled = false;
            image.color = Color.white;
        }
    }
}
