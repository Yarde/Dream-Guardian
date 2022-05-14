using System.Collections.Generic;
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
        }
    }
}
