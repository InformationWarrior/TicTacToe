using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe
{
    public class SceneController : MonoBehaviour
    {
        private const float DELAY = 3f;
        private readonly WaitForSeconds sceneLoadDelay = new(DELAY);

        private void OnEnable()
        {
            Events_TicTacToe.UI.OnPressPlay.AddListener(OnPressPlay);
            Events_TicTacToe.UI.OnPressHome.AddListener(OnPressHome);
        }

        private void OnDisable()
        {
            Events_TicTacToe.UI.OnPressPlay.RemoveListener(OnPressPlay);
            Events_TicTacToe.UI.OnPressHome.RemoveListener(OnPressHome);
        }

        private void OnPressPlay(Scenes scene)
        {
            StartCoroutine(LoadLoaderAndTargetScene(scene));
        }

        private void OnPressHome(Scenes scene)
        {
            StartCoroutine(LoadLoaderAndTargetScene(scene));
        }

        private IEnumerator LoadLoaderAndTargetScene(Scenes targetScene)
        {
            yield return LoadScene(Scenes.Loader);
            GlobalSingleton.Instance.LoaderManager.StartLoadingTargetScene(targetScene);
        }

        public IEnumerator LoadScene(Scenes scene)
        {
            yield return sceneLoadDelay;
            LoadScenes(scene, LoadSceneMode.Single);
        }

        private void LoadScenes(Scenes scene, LoadSceneMode mode)
        {
            SceneManager.LoadSceneAsync((int)scene, mode);
        }

        private void UnloadScenes(Scenes scene)
        {
            SceneManager.UnloadSceneAsync((int)scene);
        }
    }
}


















//private void OnEnable()
//{
//    Events_TicTacToe.UI.OnPressPlay.AddListener(OnPressPlay);
//    Events_TicTacToe.UI.OnPressHome.AddListener(OnPressHome);
//}

//private void OnDisable()
//{
//    Events_TicTacToe.UI.OnPressPlay.RemoveListener(OnPressPlay);
//    Events_TicTacToe.UI.OnPressHome.RemoveListener(OnPressHome);
//}

//private void OnPressPlay()
//{
//    //StartCoroutine(LoadLoaderAndTargetScene(Scenes.GamePlay));
//}

//private void OnPressHome()
//{
//    //StartCoroutine(LoadLoaderAndTargetScene(Scenes.Lobby));
//}

//private IEnumerator LoadLoaderAndTargetScene(Scenes targetScene)
//{
//    yield return LoadScene(Scenes.Loader);
//}