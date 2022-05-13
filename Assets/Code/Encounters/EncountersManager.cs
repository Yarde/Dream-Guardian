using Code.StressSystem;
using UnityEngine;

namespace Code.Encounters
{
    public class EncountersManager : MonoBehaviour
    {
        private static EncountersManager _instance;

        [SerializeField] private BaseEncounter[] _encounters;

        private void Start()
        {
            StressManager.Instance.OnClockTick += UpdateEncounters;
        }

        private void UpdateEncounters()
        {
            float stressDelta = 0;

            foreach (BaseEncounter encounter in _encounters)
            {
                if (encounter.IsEnabled)
                {
                    stressDelta += encounter.GetStress();
                }
                else
                {
                    encounter.TryEnable();
                }
            }
            
            StressManager.Instance.AddStress(stressDelta);
        }
    }
}
