using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private const float TimeToDestroy = 3f;

    private void Hide() 
    {
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        Invoke(nameof(Hide), TimeToDestroy);
    }
}
