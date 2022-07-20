using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraData : MonoBehaviour
{
    [SerializeField] private List<Transform> _cameraPoints;

    public Transform GetCameraPoint(string pointName) 
    {
        if (_cameraPoints.Exists(point => point.name == pointName))
        {
            return _cameraPoints.Find(point => point.name == pointName);
        }
        else
        {
            return this.transform;
        }         
    }
}
