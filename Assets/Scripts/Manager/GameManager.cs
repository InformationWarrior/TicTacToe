using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private SceneLoader _sceneLoader;

        public UIManager UIManager { get => _uiManager; }
        public AudioManager AudioManager { get => _audioManager; }
        public SceneLoader SceneLoader { get => _sceneLoader; }
    }
}