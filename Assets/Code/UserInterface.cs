using Code.StressSystem;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private GameObject introScreen;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private GameObject loseScreen;
        [SerializeField] private Button tryAgainButton;
        [SerializeField] private TextMeshProUGUI points;

        private StressManager _stressManager;
        
        private void Start()
        {
            _stressManager = StressManager.Instance;
            
            tryAgainButton.onClick.AddListener(Restart);
            
            introScreen.gameObject.SetActive(true);
            winScreen.gameObject.SetActive(false);
            loseScreen.gameObject.SetActive(false);
            tryAgainButton.gameObject.SetActive(false);
        }
        
        private void Restart()
        {
            tryAgainButton.interactable = false;
            _stressManager.Restart();
            SceneManager.LoadScene(0);
        }

        public async UniTask Intro()
        {
            RenderSettings.ambientLight = Color.white;
            
            introScreen.SetActive(true);
            await UniTask.Delay(1000);

            for (int i = 255; i >= 0; i--)
            {
                RenderSettings.ambientLight = new Color(i/255f, i/255f, i/255f);
                await UniTask.Delay(12);
            }
            
            await UniTask.Delay(500);

            for (int i = 0; i < _stressManager.AmbientLight.r * 255; i++)
            {
                RenderSettings.ambientLight = new Color(i/255f, i/255f, i/255f);
                await UniTask.Delay(25);
            }
            
            RenderSettings.ambientLight = _stressManager.AmbientLight;
            introScreen.SetActive(false);
        }
        
        public void OnWin()
        {
            winScreen.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
        }
        
        public void OnLost()
        {
            points.text = $"Time Lasted: {_stressManager.TimePassed*(_stressManager.TimeIncrement/1000f)} seconds";
            loseScreen.gameObject.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
        }
    }
}
