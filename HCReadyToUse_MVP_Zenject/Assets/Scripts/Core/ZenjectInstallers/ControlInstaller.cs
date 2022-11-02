using UnityEngine;
using Zenject;

public class ControlInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;

    public override void InstallBindings()
    {
        Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
    }
}