using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Misc References")]
        [SerializeField] private List<Sound> sounds = new();

        [Space]
        [Header("Asset References")]
        [SerializeField] private AudioSource bgSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private Sprite bgOn, bgOff;
        [SerializeField] private Sprite sfxOn, sfxOff;
        [SerializeField] private Image bgVolRenderImage;
        [SerializeField] private Image sfxVolRenderImage;

        [Header("Private Variables")]
        private bool isSFXSoundEnabled;
        private bool isMusicEnabled;
        private const int MIN_VOL = 0;
        private const int MAX_VOL = 60;

        private void Awake()
        {
            GlobalSingleton.Instance.AudioManager = this;
        }

        private void Start()
        {
            Initialization();
        }

        private void Initialization()
        {
            isSFXSoundEnabled = true;
            isMusicEnabled = true;

            SetInitialSound(MAX_VOL);
        }

        private AudioClip GetClip(AudioClips audioClip)
        {
            string name = ConvertToString(audioClip);
            AudioClip clip = SearchAudioClip(name);
            return clip;
        }

        private string ConvertToString(AudioClips audioClip)
        {
            return Enum.GetName(audioClip.GetType(), audioClip);
        }

        private AudioClip SearchAudioClip(string name)
        {
            return sounds.Find(s => s.name == name).clip;
        }

        private void SetInitialSound(int soundLevel)
        {
            float volume = (float)soundLevel / 100;
            UpdateMusicVolume(volume);
            UpdateSFXVolume(volume);
        }

        private void RenderSprite(Image imageRenderer, Sprite sprite)
        {
            if (imageRenderer != null && sprite != null)
            {
                imageRenderer.sprite = sprite;
            }
        }

        #region Music

        public void PlayMusic(AudioClips audioClip)
        {
            bgSource.loop = true;
            bgSource.playOnAwake = true;
            bgSource.clip = GetClip(audioClip);
            bgSource.Play();
        }

        public void OnMusicButtonTap()
        {
            PlaySFX(AudioClips.ButtonClick);

            isMusicEnabled = !isMusicEnabled;

            print($"{isMusicEnabled} >>>> isMusicEnabled");

            if (isMusicEnabled)
            {
                UpdateMusicVolume(MAX_VOL);
            }

            else
            {
                UpdateMusicVolume(MIN_VOL);
            }
        }

        private void UpdateMusicVolume(float volume)
        {
            bgSource.volume = volume;
            RenderMusicSprite(volume);
        }

        private void RenderMusicSprite(float volume)
        {
            if (volume > MIN_VOL)
                RenderSprite(bgVolRenderImage, bgOn);
            else
                RenderSprite(bgVolRenderImage, bgOff);
        }

        #endregion

        #region SFX

        public void PlaySFX(AudioClips audioClip)
        {
            AudioClip clip = GetClip(audioClip);

            if (clip != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }

        public void OnSFXButtonTap()
        {
            PlaySFX(AudioClips.ButtonClick);
        }

        private void UpdateSFXVolume(float volume)
        {
            sfxSource.volume = volume;
            RenderSFXSprite(volume);
        }

        private void RenderSFXSprite(float volume)
        {
            if (volume > 0)
                RenderSprite(sfxVolRenderImage, sfxOn);
            else
                RenderSprite(sfxVolRenderImage, sfxOn);
        }
        #endregion
    }
}