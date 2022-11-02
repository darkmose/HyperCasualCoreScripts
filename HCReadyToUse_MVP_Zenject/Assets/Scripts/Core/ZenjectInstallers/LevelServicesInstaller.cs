using Core.Level;
using UnityEngine;
using Zenject;

public class LevelServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelController>().To<LevelController>().AsSingle();
    }
}