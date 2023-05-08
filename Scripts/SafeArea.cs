using UnityEngine;

namespace PocketApps.Utils {
    [ExecuteAlways]
    public class SafeArea : MonoBehaviour {

        [SerializeField]
        private RectTransform target;

        [SerializeField]
        private bool logsEnabled = false;

        [SerializeField]
        private bool executeInEditor = true;

        private Rect recentSafeArea = Rect.zero;

        private void Start() {
            Layout();
        }

        private void Update() {
            Layout();
        }

        private void Layout() {
            if (!Application.isPlaying && !executeInEditor) {
                // if we in the edit mode and it's disabled - fish execution 
                return;
            }

            Rect safeArea = Screen.safeArea;
            if (recentSafeArea == safeArea) {
                return;
            };

            recentSafeArea = safeArea;

            /* Let's convert safe area rect from absolute pixels to normalized anchor coordinates */
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            target.anchorMin = anchorMin;
            target.anchorMax = anchorMax;

            if (logsEnabled) {
                Debug.LogFormat(
                    "New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}",
                    name,
                    safeArea.x,
                    safeArea.y,
                    safeArea.width,
                    safeArea.height,
                    Screen.width,
                    Screen.height
                );
            }
        }
    }
}
