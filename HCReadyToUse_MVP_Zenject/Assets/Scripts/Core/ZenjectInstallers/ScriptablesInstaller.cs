using Configuration;
using Core.Resourses;
using UnityEngine;
using Zenject;

public class ScriptablesInstaller : MonoInstaller
{
    [SerializeField] private GameConfiguration _gameConfiguration;
    [SerializeField] private ResourceHolder _resourceHolder;

    public override void InstallBindings()
    {
        Container.Bind<GameConfiguration>().FromInstance(_gameConfiguration).AsSingle();
        Container.Bind<ResourceHolder>().FromInstance(_resourceHolder).AsSingle();
    }
}