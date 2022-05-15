using Code.StressSystem;
using Code.Utils;
using DG.Tweening;
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
            StressManager.Instance.OnClockTick += OnClockTick;
            StressManager.Instance.OnStressUpdated += OnStressUpdate;
        }
        private void OnClockTick()
        {
            playerLight.intensity = baseIntensity * (1 - StressManager.Instance.StressRatio * 0.75f);
        }
        
        private void OnStressUpdate()
        {
            roomPosition.DOLocalMove(new Vector3(roomPosition.position.x, roomPosition.position.y, 14.13f + StressManager.Instance.StressMeter / 25), 5f);
        }

        private void Update()
        {
            transform.localPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition.WithZ(roomPosition.position.z)).WithZ(-3f);
        }
    }
}
