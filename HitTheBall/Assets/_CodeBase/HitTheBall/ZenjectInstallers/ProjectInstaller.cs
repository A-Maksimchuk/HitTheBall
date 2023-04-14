using HitTheBall.SceneManagement;
using Zenject;

namespace HitTheBall.ZenjectInstallers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneManager>().AsSingle();
        }
    }
}
