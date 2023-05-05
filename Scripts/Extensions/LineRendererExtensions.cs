using UnityEngine;

namespace PocketApps.Utils {
    public static class LineRendererExtensions {
        /// <summary> Renders a circle in the XZ plane </summary>
        public static void RenderCircleXZ(this LineRenderer renderer, Vector3 center, float radius, int segments) {
            renderer.positionCount = segments + 1;

            for (int step = 0; step <= segments; step++) {
                var progress = (float)step / segments;
                var angle = progress * 2.0f * Mathf.PI;
                var circlePosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                var position = (circlePosition * radius).ToXYZ() + center;
                renderer.SetPosition(step, position);
            }
        }

        /// <summary> Removes all rendered contents </summary>
        public static void Reset(this LineRenderer renderer) {
            renderer.positionCount = 0;
        }
    }
}
