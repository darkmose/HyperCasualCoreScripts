using System.Collections;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager _instanceInner;

    private static CoroutineManager _instance
    {
        get
        {
            if(_instanceInner == null)
            {
                var go = new GameObject("CoroutineManager");
                _instanceInner = go.AddComponent<CoroutineManager>();
            }
            return _instanceInner;
        }
    }

    private void Awake()
    {
        _instanceInner = this;
        DontDestroyOnLoad(this);
    }

    public static void StartCoroutineMethod(IEnumerator coroutine)
    {
        _instance.StartCoroutine(coroutine);
    }

    public static void StopCoroutineMethod(IEnumerator coroutine)
    {
        _instance.StopCoroutine(coroutine);
    }

    private IEnumerator DelayedActionInner(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    public static void DelayedAction(float delay, System.Action action)
    {
        _instance.StartCoroutine(_instance.DelayedActionInner(delay, action));
    }

    public static Coroutine StartCoroutineMethodReaply(IEnumerator coroutine)
    {
       return _instance.StartCoroutine(coroutine);
    }

    public static void StopCoroutineMethodReaply(Coroutine coroutine)
    {
        _instance.StopCoroutine(coroutine);
    }

    public static void NextFrameAction(System.Action Action, int countFrame = 1)
    {
        _instance.StartCoroutine(_instance.NextFrameActionInner(countFrame, Action));
    }

    private IEnumerator NextFrameActionInner(int countFrame, System.Action action)
    {
        while(countFrame > 0)
        {
            yield return new WaitForEndOfFrame();
            countFrame--;
        }
        action?.Invoke();
    }
}