using System.Collections.Generic;
using Code.StressSystem;
using UnityEngine;

namespace Code.Music
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<float> stressThreshold;
        [SerializeField] private List<AudioClip> musicFiles;

        private void Start()
        {
            audioSource.clip = musicFiles[0];
            audioSource.Play();

            StressManager.Instance.OnStressUpdated += OnStressChanged;
        }
        
        private void OnStressChanged()
        {
            AudioClip clip = musicFiles[0];

            for (var i = 0; i < stressThreshold.Count; i++)
            {
                float stressLevel = stressThreshold[i];
                if (StressManager.Instance.StressMeter > stressLevel)
                {
                    clip = musicFiles[i];
                }
                else
                {
                    break;
                }
            }

            audioSource.clip = clip;
        }
    }
}
