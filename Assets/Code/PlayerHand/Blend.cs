using Code.StressSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Code.PlayerHand
{
    public class LightBlend : MonoBehaviour
    {
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            
            _image.color = StressManager.Instance.BlendColor;
        }
    }
}
