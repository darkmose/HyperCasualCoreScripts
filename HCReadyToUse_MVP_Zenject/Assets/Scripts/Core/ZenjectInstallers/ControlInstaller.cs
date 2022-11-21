using Core.ControlLogic;
using UnityEngine;
using Zenject;

public class ControlInstaller : MonoInstaller
{
    [SerializeField] private ControlPanelView _gameScreenControlPanel;

    public override void InstallBindings()
    {
        Container.Bind<IControlPanel>().WithId("GameControlPanel").To<ControlPanelView>().FromInstance(_gameScreenControlPanel).AsSingle();
    }
}