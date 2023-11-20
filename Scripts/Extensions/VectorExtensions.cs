using UnityEngine;

namespace PocketApps.Utils {
    public static class Vector2Extensions {
        /// <summary> Converts Vector2 to Vector3 in 3D coordinates system </summary>
        public static Vector3 ToXYZ(this Vector2 v2, float y = 0.0f) {
            return new Vector3(v2.x, y, v2.y);
        }
        
         /// <summary> Change Vector2's specific coordinate values </summary>
        public static Vector2 With(this Vector2 v2, float? x = null, float? y = null) {
            return new Vector2( 
                x ?? v2.x,
                y ?? v2.y
            );
        }
    }

    public static class Vector3Extensions {
        /// <summary> Converts Vector3 to Vector2 in 3D coordinates system </summary>
        public static Vector2 ToXZ(this Vector3 v3) {
            return new Vector2(v3.x, v3.z);
        }
        
        /// <summary> Change Vector3's specific coordinate values </summary>
        public static Vector3 With(this Vector3 v3, float? x = null, float? y = null, float? z = null) {
            return new Vector3( 
                x ?? v3.x,
                y ?? v3.y,
                z ?? v3.z
            );
        }
    }
}
