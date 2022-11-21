using Core.MVP;
using Core.UI;
using UnityEngine;
using Zenject;

public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] private UIManager _uIManager;

    public override void InstallBindings()
    {
        Container.Bind<GameScreenModel>().AsSingle();
        Container.Bind<GameScreenUseCases>().AsSingle();
        Container.Bind<GameScreenProxyView>().AsSingle();
        Container.Bind<IGameScreenPresenter>().To<GameScreenPresenter>().AsSingle();
        
        Container.Bind<LobbyScreenModel>().AsSingle();
        Container.Bind<LobbyScreenUseCases>().AsSingle();
        Container.Bind<LobbyScreenProxyView>().AsSingle();
        Container.Bind<ILobbyScreenPresenter>().To<LobbyScreenPresenter>().AsSingle();        

        Container.Bind<UIManager>().FromInstance(_uIManager).AsSingle();
    }
}