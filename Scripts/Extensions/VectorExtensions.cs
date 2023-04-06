using UnityEngine;

namespace PocketUtils {
    public static class VectorExtensions {
        public static Vector2 ToXZ(this Vector3 v3) {
            return new Vector2(v3.x, v3.z);
        }

        public static Vector3 ToXYZ(this Vector2 v2, float y = 0.0f) { 
            return new Vector3(v2.x, y, v2.y); 
        }
    }
}
