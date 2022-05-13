using UnityEngine;

namespace Code.PlayerHand
{
    public class LightCutoff : MonoBehaviour
    {
        private void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}
