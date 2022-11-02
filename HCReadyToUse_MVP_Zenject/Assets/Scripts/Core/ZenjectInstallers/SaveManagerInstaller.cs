using UnityEngine;
using Zenject;

public class SaveManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SaveManager>().AsSingle().NonLazy();
    }
}