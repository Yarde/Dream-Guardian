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

        public StressManager()
        {
            _encountersData = Resources.Load<EncountersData>("EncountersData");
            _difficultyData = Resources.Load<DifficultyData>("Medium");
        }
        
        public float StressMeter { get; private set; }
        public float TimePassed { get; private set; }
    }

}
