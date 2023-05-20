using System;
using UnityEngine;

namespace PocketApps.Utils {
    public class Singleton<T> : MonoBehaviour where T : Singleton<T> {
        private static T _instance;

        public static T Instance {
            get {
                if (_instance) {
                    return _instance;
                }

                var objects = FindObjectsOfType<T>();

                if (objects.Length == 0) {
                    var gameObject = new GameObject($"[{TypeName}]");
                    DontDestroyOnLoad(gameObject);
                    var instance = gameObject.AddComponent<T>();
                    _instance = instance;
                    return _instance;
                }

                if (objects.Length > 1) {
                    Debug.LogError($"There are more than one instance of {TypeName}!");
                }

                _instance = objects[0];
                return _instance;
            }
        }
        
        public static T HasInstance { 
            get {
                return _instance != null;
            }
        }

        private static string TypeName {
            get {
                return typeof(T).Name;
            }
        }
    }
}
