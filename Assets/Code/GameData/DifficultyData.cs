using UnityEngine;

namespace Code.StressSystem
{
    [CreateAssetMenu(menuName = "Player/DifficultyData")]
    public class DifficultyData : ScriptableObject
    {
        public Color blendColor;
        
        public float cutoffSize;
        public float cutoffStressDecrease;
        
        public float maxStress;
        public float ticksToWin;
        public int ticksTimeMilliseconds;
        public float stressDecrementPerTick;
        public float spawnProbabilityIncrementPerTick;
        public float spawnProbabilityMultiplier;
    }
}
