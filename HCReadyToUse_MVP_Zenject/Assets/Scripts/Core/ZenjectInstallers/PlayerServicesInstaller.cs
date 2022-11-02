using Core.PlayerModule;
using UnityEngine;
using Zenject;

namespace Core.CameraLogic
{
    public class PlayerServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IWallet>().To<Wallet>().AsSingle();
            Container.Bind<ILevelProgression>().To<LevelProgression>().AsSingle();
            Container.Bind<ISettings>().To<Settings>().AsSingle();
            Container.Bind<IPrivacyPolicy>().To<PrivacyPolicy>().AsSingle();
            Container.Bind<IPlayer>().To<Player>().AsSingle();
        }
    }
}