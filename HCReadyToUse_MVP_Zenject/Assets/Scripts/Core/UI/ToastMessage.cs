using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ToastMessage : MonoBehaviour
{
    private enum ToastType
    {
        Message, 
        Image
    }

    [SerializeField] private ToastType _toastType;
    [SerializeField] private TextMeshProUGUI _toastMessage;
    [SerializeField] private Image _toastImage;
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private float _moveHeight = 10f;
    [SerializeField] private float _moveDuration = 1f;

    private Vector3 _target;

    public void InitMovePosition(Vector3 target)
    {
        _target = target;
    }

    public void InitMessage(string message)
    {
        _toastMessage.text = message;
    }

    public void SetToast(System.Action onComplete = null) 
    {
        switch (_toastType)
        {
            case ToastType.Message:
                ToastText(onComplete);
                break;
            case ToastType.Image:
                ToastImage(onComplete);
                break;
            default:
                break;
        }

    }

    private void ToastText(System.Action onComplete = null)
    {
        _toastMessage.color = Color.white;
        var posY = transform.localPosition.y;
        var halfMoveUp = transform.DOLocalMoveY(posY + _moveHeight, _moveDuration);
        var fade = _toastMessage.DOFade(0, _fadeDuration);
        DOTween.Sequence().Append(halfMoveUp).Join(fade).SetEase(Ease.Linear).OnComplete(() =>
        {
            this.gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }

    private void ToastImage(System.Action onComplete = null)
    {
        transform.DOMove(_target, _moveDuration).SetEase(Ease.Linear).OnComplete(()=> 
        {
            this.gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }


    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
