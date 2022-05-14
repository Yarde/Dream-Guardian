using Code.StressSystem;
using Code.Utils;
using UnityEngine;

namespace Code.PlayerHand
{
    public class LightCutoff : MonoBehaviour
    {
        [SerializeField] private Transform roomPosition;
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
            transform.localPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition.WithZ(roomPosition.position.z)).WithZ(-3f);
        }
    }
}
