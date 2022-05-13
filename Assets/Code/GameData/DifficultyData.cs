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
        public int timeIncrement;
        public int stressDecrement;
    }
}
