using System.Threading;
using Code.StressSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code
{
    public class RootFlow : MonoBehaviour
    {
        private StressManager _stressManager;
        private CancellationTokenSource _cancellationToken;

        [SerializeField] private UserInterface ui;
        [SerializeField] private bool isInfinite;

        private void Start()
        {
            Cursor.visible = false;

            StressManager.Infinite = isInfinite;
            _stressManager = StressManager.Instance;
            _stressManager.OnWin += OnWin;
            _stressManager.OnLost += OnLost;
            
            StartGame();
        }
        
        private void StartGame()
        {
            _cancellationToken = new CancellationTokenSource();
            RunLoop().Forget();
        }

        private void OnWin()
        {
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();
            
            ui.OnWin();
        }

        private void OnLost()
        {
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();

            ui.OnLost();
        }

        private async UniTask RunLoop()
        {
            await ui.Intro();

            while (!_cancellationToken.IsCancellationRequested)
            {
                await UniTask.Delay(_stressManager.TimeIncrement);
                _stressManager.ClockTick();
            }
        }
    }
}
