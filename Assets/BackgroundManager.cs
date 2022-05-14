using Code.StressSystem;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject fog;
    
    private void Start()
    {
        StressManager.Instance.OnStressUpdated += OnStressUpdate;
    }
    private void OnStressUpdate()
    {
        fog.SetActive(StressManager.Instance.TimePassed > 100);
    }
}
