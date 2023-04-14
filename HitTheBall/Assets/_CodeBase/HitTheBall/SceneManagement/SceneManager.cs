using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HitTheBall.SceneManagement
{
    public class SceneManager
    {
        private const string BootScene = "Boot";
        private const string GameScene = "Game";

        public async UniTask LoadScene(string sceneName)
        {
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        }

        public async UniTask LoadBootScene()
        {
            await LoadScene(BootScene);
        }

        public async UniTask LoadGameScene()
        {
            await LoadScene(GameScene);
        }
    }
}
