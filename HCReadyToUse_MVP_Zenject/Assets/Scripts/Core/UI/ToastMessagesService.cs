using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ToastMessagesService : MonoBehaviour
{
    public enum ToastImageType
    {
        Money
    }

    private const string ToastMessageTagName = "ToastMessage";
    private const string ToastMoneyTagName = "ToastImageMoney";

    private ObjectPooler<ToastMessage> _objectPooler;
    [SerializeField] private Transform _messagesRoot;
    [SerializeField] private Transform _imagesRoot;

    [Inject]
    public void Constructor(ObjectPooler<ToastMessage> objectPooler)
    {
        _objectPooler = objectPooler;
    }

    public void SetToastMessage(string message, Vector3 startPosition, System.Action onComplete = null)
    {
        var toastMessage = _objectPooler.GetPooledGameObject(ToastMessageTagName);
        toastMessage.transform.SetParent(_messagesRoot);
        toastMessage.transform.localScale = Vector3.one;
        toastMessage.transform.position = startPosition;
        toastMessage.InitMessage(message);
        toastMessage.SetToast(onComplete);
    }

    public void SetToastImage(ToastImageType toastImageType, Vector3 startPosition, Vector3 moveTarget, System.Action onComplete = null)
    {
        ToastMessage toastMessage;
        switch (toastImageType)
        {
            case ToastImageType.Money:
                toastMessage = _objectPooler.GetPooledGameObject(ToastMoneyTagName);
                break;
            default:
                toastMessage = _objectPooler.GetPooledGameObject(ToastMoneyTagName);
                break;
        }

        toastMessage.transform.SetParent(_imagesRoot);
        toastMessage.transform.localScale = Vector3.one;
        toastMessage.transform.position = startPosition;
        toastMessage.InitMovePosition(moveTarget);
        toastMessage.SetToast(onComplete);
    }
}
