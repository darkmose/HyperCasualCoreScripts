using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.CameraLogic
{
    public enum CameraType
    {
        Main
    }

    public interface ICamerasManager
    {
        Camera GetCamera(CameraType cameraType);
    }

    class CamerasManager : MonoBehaviour, ICamerasManager
    {
        [SerializeField] private Camera _mainCamera;


        public Camera GetCamera(CameraType cameraType)
        {
            switch (cameraType)
            {
                case CameraType.Main:
                    return _mainCamera;
                default:
                    return _mainCamera;
            }
        }
    }
}
