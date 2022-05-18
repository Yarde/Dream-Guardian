using Code.StressSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button[] modeButtons;
        [SerializeField] private string[] modeSettings;

        private void Start()
        {
            Cursor.visible = true;
            Debug.Log("Menu Started");
            
            for (var i = 0; i < modeButtons.Length; i++)
            {
                Button button = modeButtons[i];
                string setting = modeSettings[i];
                
                button.onClick.AddListener(() => StartGame(setting));
            }
        }
        
        private void StartGame(string setting)
        {
            StressManager.Instance = new StressManager(setting);
            SceneManager.LoadScene(1);
        }
    }
}
