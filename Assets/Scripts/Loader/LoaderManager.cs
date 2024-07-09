using System.Collections;
using SingletonPattern;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

namespace TicTacToe
{
    public class LoaderManager : Singleton<LoaderManager>
    {
        [SerializeField] private Slider slider;
        private static AsyncOperationHandle<SceneInstance> sceneLoadOpHandle;
        public Scenes TargetScene { get; set; } = Scenes.Lobby;

        private void Awake()
        {
            GlobalSingleton.Instance.LoaderManager = this;
        }

        public void StartLoadingTargetScene(Scenes targetScene)
        {
            StartCoroutine(LoadAddressableScenes(targetScene));
        }

        private IEnumerator LoadAddressableScenes(Scenes scene)
        {
            sceneLoadOpHandle = Addressables.LoadSceneAsync(scene.ToString(), activateOnLoad: true);

            while (!sceneLoadOpHandle.IsDone)
            {
                slider.value = sceneLoadOpHandle.PercentComplete;
                yield return null;
            }

            if (sceneLoadOpHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log($"Successfully loaded addressable scene: {scene}");
            }

            else
            {
                Debug.LogError($"Failed to load addressable scene: {scene}. Error: {sceneLoadOpHandle.OperationException}");
            }
        }
    }
}