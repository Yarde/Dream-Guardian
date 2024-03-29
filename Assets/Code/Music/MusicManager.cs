﻿using System.Collections.Generic;
using Code.StressSystem;
using UnityEngine;

namespace Code.Music
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<float> tickThreshold;
        [SerializeField] private List<AudioClip> musicFiles;
        
        [SerializeField] private AudioClip winMusic;
        [SerializeField] private AudioClip lossMusic;

        private void Start()
        {
            audioSource.Play();

            StressManager.Instance.OnClockTick += OnClockTick;
            StressManager.Instance.OnWin += OnWinMusic;
            StressManager.Instance.OnLost += OnLostMusic;
        }
        private void OnLostMusic()
        {
            StressManager.Instance.OnClockTick -= OnClockTick;
            audioSource.clip = lossMusic;
            audioSource.Play();
        }
        private void OnWinMusic()
        {
            StressManager.Instance.OnClockTick -= OnClockTick;
            audioSource.clip = winMusic;
            audioSource.Play();
        }

        private void OnClockTick()
        {
            AudioClip clip = musicFiles[0];

            for (var i = 0; i < tickThreshold.Count; i++)
            {
                float threshold = tickThreshold[i];
                if (StressManager.Instance.TimePassed > threshold)
                {
                    clip = musicFiles[i];
                }
                else
                {
                    break;
                }
            }
            
            if (audioSource.clip != clip)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
