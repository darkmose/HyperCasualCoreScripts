using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastMessagesService : MonoBehaviour
{
    private const string ToastMessageTagName = "ToastMessage";
    private ObjectPooler _objectPooler;

    private void Awake()
    {
        Core.DISimple.ServiceLocator.Register<ToastMessagesService>(this);
    }

    private void Start()
    {
        _objectPooler = Core.DISimple.ServiceLocator.Resolve<ObjectPooler>();
    }

    public void SetToastMessage(string message) 
    {
        var toastMessageObject = _objectPooler.GetPooledGameObject(ToastMessageTagName);
        toastMessageObject.transform.SetParent(this.transform);
        toastMessageObject.transform.localScale = Vector3.one;
        toastMessageObject.transform.localPosition = Vector3.zero;
        if (toastMessageObject.TryGetComponent(out ToastMessage toastMessage))
        {
            toastMessage.SetMessage(message);
        }
    }

    private void OnDestroy()
    {
        Core.DISimple.ServiceLocator.Unregister<ToastMessagesService>();
    }
}
