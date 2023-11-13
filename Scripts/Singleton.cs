using System.Linq;
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
                    _instance = CreateInstance();
                    return _instance;
                }

                if (objects.Length > 1) {
                    Debug.LogWarning($"There are more than one instance of {TypeName}! Let's keeping the first one and destroy others");
                    objects.Skip(1).ToList().ForEach((o) => Destroy(o.gameObject));
                }

                _instance = objects[0];
                return _instance;
            }
        }

        public virtual bool isPeristent {
            get => true;
        }

        public static bool HasInstance {
            get => _instance != null;
        }

        private static string TypeName {
            get => typeof(T).Name;
        }

        protected virtual void Awake() {
            if (_instance == null) {
                _instance = this as T;
            }

            if (_instance.GetInstanceID() != GetInstanceID()) {
                Destroy(gameObject);
                return;
            }

            if (isPeristent) {
                // in order do not be destroyed on load it must be without a parent
                gameObject.transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }
        }

        protected virtual void OnDestroy() {
            if (_instance == this) {
                _instance = null;
            }
        }

        private static T CreateInstance() {
            var gameObject = new GameObject($"[{TypeName}]");
            var instance = gameObject.AddComponent<T>();
            return instance;
        }
    }
}
