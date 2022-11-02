using Core.DISimple;
using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ServiceLocator.Register<DiContainer>(Container);
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<DiContainer>();
    }
}