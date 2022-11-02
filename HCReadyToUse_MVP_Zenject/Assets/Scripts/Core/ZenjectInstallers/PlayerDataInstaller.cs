using Core.GameLogic;
using UnityEngine;
using Zenject;

public class PlayerDataInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;

    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
    }
}