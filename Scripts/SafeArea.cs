using UnityEngine;

namespace PocketApps.Utils {
    public class SafeArea : MonoBehaviour {

        [SerializeField]
        private RectTransform _target;

        private Rect _recentSafeArea = new Rect(0, 0, 0, 0);

        private void Awake() {
            Layout();
        }

        private void Start() {
            Layout();
        }

        private void FixedUpdate() {
            Layout();
        }

        private void Layout() {
            Rect safeArea = Screen.safeArea;

            if (_recentSafeArea == safeArea) {
                return;
            };

            _recentSafeArea = safeArea;

            /// Let's convert safe area rect from absolute pixels to normalized anchor coordinates
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            _target.anchorMin = anchorMin;
            _target.anchorMax = anchorMax;

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
