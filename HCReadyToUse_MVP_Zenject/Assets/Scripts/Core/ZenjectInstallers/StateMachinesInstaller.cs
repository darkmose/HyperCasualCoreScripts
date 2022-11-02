using Core.States;
using UnityEngine;
using Zenject;

public class StateMachinesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var applicationStateMachine = new BaseStateMachine<ApplicationStates>();
        var gameplayStateMachine = new BaseStateMachine<GameplayStates>();

        Container.Bind<LoadingState>().AsSingle();
        Container.Bind<GameplayState>().AsSingle();
        Container.Bind<PrepareState>().AsSingle();
        Container.Bind<GameState>().AsSingle();
        Container.Bind<LobbyState>().AsSingle();
        Container.Bind<IStateMachine<ApplicationStates>>().FromInstance(applicationStateMachine).AsSingle();
        Container.Bind<IStateMachine<GameplayStates>>().FromInstance(gameplayStateMachine).AsSingle();
    }
}