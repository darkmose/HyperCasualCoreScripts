using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.CameraLogic
{
    public class CameraPointsHolder : MonoBehaviour
    {
        [SerializeField] private List<Transform> _cameraPoints;

        public Transform GetCameraTransform(string pointName)
        {
            if (_cameraPoints.Exists(point => point.name == pointName))
            {
                return _cameraPoints.Find(point => point.name == pointName);
            }
            else
            {
                return transform;
            }
        }

    }
}