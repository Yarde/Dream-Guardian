using System.Threading;
using Code.StressSystem;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class RootFlow : MonoBehaviour
    {
        private StressManager _stressManager;
        private CancellationTokenSource _cancellationToken;

        [SerializeField] private GameObject introScreen;
        [SerializeField] private GameObject loseScreen;
        [SerializeField] private TextMeshProUGUI points;

        private void Start()
        {
            _stressManager = StressManager.Instance;
            _stressManager.OnLost += OnLost;
            StartGame();
        }
        
        private void StartGame()
        {
            _cancellationToken = new CancellationTokenSource();
            RunLoop().Forget();
        }

        private void OnLost()
        {
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();

            ShowLostScreen().Forget();
        }
        
        private async UniTask ShowLostScreen()
        {
            loseScreen.SetActive(true);
            points.text = $"Time Lasted: {_stressManager.TimePassed*(_stressManager.TimeIncrement/1000f)} seconds";
            await UniTask.Delay(10000);
            _stressManager.Restart();
            SceneManager.LoadScene(0);
        }

        private async UniTask RunLoop()
        {
            RenderSettings.ambientLight = Color.white;
            for (int i = 255; i > 15; i--)
            {
                RenderSettings.ambientLight = new Color(i/255f, i/255f, i/255f);
                await UniTask.Delay(10);
            }

            while (!_cancellationToken.IsCancellationRequested)
            {
                await UniTask.Delay(_stressManager.TimeIncrement);
                _stressManager.ClockTick();
            }
        }
    }
}
