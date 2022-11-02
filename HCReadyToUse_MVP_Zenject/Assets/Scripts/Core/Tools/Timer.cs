using System;
using DG.Tweening;

namespace Core.Tools
{ 
    public static class Timer
    {
        public static Tweener SetTimer(float time, System.Action onComplete)
        {
            var currentTime = time;
            return DOTween.To(() => currentTime, newTime => currentTime = newTime, 0, time).OnComplete(() =>
            {
                onComplete?.Invoke();
            });
        }
    }
}