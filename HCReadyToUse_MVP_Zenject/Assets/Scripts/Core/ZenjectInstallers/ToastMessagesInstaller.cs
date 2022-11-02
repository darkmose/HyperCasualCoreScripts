using UnityEngine;
using Zenject;

public class ToastMessagesInstaller : MonoInstaller
{
    [SerializeField] private ToastMessagesService _toastMessagesService;

    public override void InstallBindings()
    {
        Container.Bind<ToastMessagesService>().FromInstance(_toastMessagesService).AsSingle().NonLazy();
    }
}