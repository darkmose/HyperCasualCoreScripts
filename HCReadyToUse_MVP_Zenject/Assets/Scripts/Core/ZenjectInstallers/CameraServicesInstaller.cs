using UnityEngine;
using Zenject;
using Core.CameraLogic;

public class CameraServicesInstaller : MonoInstaller
{
    [SerializeField] private CameraPointsHolder _cameraPointsHolder;
    [SerializeField] private CamerasManager _camerasManager;

    public override void InstallBindings()
    {
        Container.Bind<CameraPointsHolder>().FromInstance(_cameraPointsHolder).AsSingle();
        Container.Bind<ICamerasManager>().FromInstance(_camerasManager).AsSingle();
    }

}