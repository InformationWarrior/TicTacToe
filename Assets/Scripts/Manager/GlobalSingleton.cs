using SingletonPattern;
using UnityEngine;

namespace TicTacToe
{
    public class GlobalSingleton : Singleton<GlobalSingleton>
    {
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private LoaderManager _loaderManager;

        public SceneController SceneController { get => _sceneController; }
        public LoaderManager LoaderManager { set => _loaderManager = value; get => _loaderManager; }
        public AudioManager AudioManager { set => _audioManager = value; get => _audioManager; }

        protected override void OnAwake()
        {
            base.OnAwake();
            StartCoroutine(_sceneController.LoadScene(Scenes.Loader));
        }
    }
}