using UnityEngine;
using Zenject;

public class ObjectPoolerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var rootOfToastMessages = new GameObject("ToastMessagesRoot");
        var toastMessagesPoller = new ObjectPooler<ToastMessage>(rootOfToastMessages.transform, false);
        Container.Bind<ObjectPooler<ToastMessage>>().FromInstance(toastMessagesPoller).AsSingle();
    }
}