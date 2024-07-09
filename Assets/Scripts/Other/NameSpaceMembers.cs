using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe
{
    [Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public enum AudioClips { None, ButtonClick, BackgroundMusic }

    public enum Scenes { None = -1, Splash, Loader, Lobby, GamePlay }
}