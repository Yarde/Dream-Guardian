using Code.StressSystem;
using Code.Utils;
using UnityEngine;

namespace Code.PlayerHand
{
    public class LightCutoff : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Light playerLight;
        [SerializeField] private float baseIntensity;
        
        private void Start()
        {
            StressManager.Instance.OnClockTick += OnStressUpdate;
        }
        private void OnStressUpdate()
        {
            playerLight.intensity = baseIntensity * (1 - StressManager.Instance.StressRatio * 0.75f);
        }

        private void Update()
        {
            transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition.WithZ(9.36f)).WithZ(5f);
        }
    }
}
