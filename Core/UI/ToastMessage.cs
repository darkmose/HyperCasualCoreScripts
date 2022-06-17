using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToastMessage : MonoBehaviour
{
    [SerializeField] private Text _toastMessage;
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private float _moveHeight = 10f;
    [SerializeField] private float _moveDuration = 1f;
    public void SetMessage(string message) 
    {
        _toastMessage.color = Color.white;
        _toastMessage.text = message;
        var posY = transform.localPosition.y;
        var halfMoveUp = transform.DOLocalMoveY(posY + _moveHeight, _moveDuration);
        var fade = _toastMessage.DOFade(0, _fadeDuration);
        DOTween.Sequence().Append(halfMoveUp).Join(fade).OnComplete(()=> 
        {
            this.gameObject.SetActive(false);
        });
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
