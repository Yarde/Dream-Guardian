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

        private void Start()
        {
            _stressManager = StressManager.Instance;
            _cancellationToken = new CancellationTokenSource();

            RunLoop().Forget();
        }

        private async UniTask RunLoop()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                await UniTask.Delay(_stressManager.TimeIncrement);
                _stressManager.ClockTick();
            }
        }
    }
}
