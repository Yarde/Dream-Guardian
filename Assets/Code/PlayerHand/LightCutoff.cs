using Code.StressSystem;
using DG.Tweening;
using UnityEngine;

namespace Code.PlayerHand
{
    public class LightCutoff : MonoBehaviour
    {
        private void Start()
        {
            StressManager.Instance.OnStressUpdate += OnStressUpdate;
        }
        private void OnStressUpdate()
        {
            transform.DOScale(StressManager.Instance.CutoffSize, 0.1f);
        }

        private void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}
