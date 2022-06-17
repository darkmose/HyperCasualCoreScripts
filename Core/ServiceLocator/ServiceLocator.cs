using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.DISimple
{

    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void Register<TService>(TService service)
        {
            if (_services.ContainsKey(typeof(TService)) == true)
            {
                Debug.LogError($"Service {typeof(TService).Name} already exist");
            }
            else
            {
                _services[typeof(TService)] = service;
            }
        }

        public static void Unregister<TService>()
        {
            if (_services.ContainsKey(typeof(TService)) == false)
            {
                Debug.LogError($"Service {typeof(TService).Name} did not exist");
            }
            else
            {
                _services.Remove(typeof(TService));
            }
        }

        public static bool IsServiceExist<TService>()
        {
            return _services.ContainsKey(typeof(TService));
        }

        public static TService Resolve<TService>()
        {
            if (_services.ContainsKey(typeof(TService)) == false)
            {
                Debug.LogError($"Service {typeof(TService).Name} did not exist");
                return default;
            }
            else
            {
                return (TService)_services[typeof(TService)];
            }
        }
    }
}