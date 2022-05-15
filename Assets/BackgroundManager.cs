using Code.StressSystem;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject fog;
    [SerializeField] private GameObject goodRoom;
    
    private void Start()
    {
        StressManager.Instance.OnStressUpdated += OnStressUpdate;
        StressManager.Instance.OnClockTick += OnGameStarted;
        StressManager.Instance.OnWin += OnGameStarted;
        
        fog.SetActive(false);
    }
    
    private void OnGameStarted()
    {
        goodRoom.SetActive(false);
        fog.SetActive(false);
    }
    
    private void OnStressUpdate()
    {
        fog.SetActive(StressManager.Instance.TimePassed > 100);
    }
}
