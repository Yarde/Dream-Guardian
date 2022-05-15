using Code.StressSystem;
using DG.Tweening;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject fog;
    [SerializeField] private GameObject goodRoom;
    [SerializeField] private Transform roomPosition;
    
    private void Start()
    {
        StressManager.Instance.OnStressUpdated += OnStressUpdate;
        StressManager.Instance.OnClockTick += OnGameStarted;
        StressManager.Instance.OnWin += OnGameWin;
        
        fog.SetActive(false);
    }
    
    private void OnGameStarted()
    {
        StressManager.Instance.OnClockTick -= OnGameStarted;
        goodRoom.SetActive(false);
        fog.SetActive(false);
    }
    
    private void OnGameWin()
    {
        goodRoom.SetActive(false);
        fog.SetActive(false);
        roomPosition.DOLocalMove(new Vector3(0, -0.67f, 7f), 0.01f);
    }

    private void OnStressUpdate()
    {
        fog.SetActive(StressManager.Instance.TimePassed > 100);
    }
}
