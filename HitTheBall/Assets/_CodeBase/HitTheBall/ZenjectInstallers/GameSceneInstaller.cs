using HitTheBall.GamePlay.HittableObjects;
using HitTheBall.Infrastructure;
using HitTheBall.SceneManagement;
using UnityEngine;
using Zenject;

namespace HitTheBall.ZenjectInstallers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private HittableObjectsManager hittableObjectsManager;
        [Inject]
        private void Init(SceneManager sceneManager)
        {
            if (!Boot.IsLoadingCompleteCorrectly)
                sceneManager.LoadBootScene();
        }

        public override void InstallBindings()
        {
            Container.BindInstance(hittableObjectsManager).AsSingle();
        }
    }
}
