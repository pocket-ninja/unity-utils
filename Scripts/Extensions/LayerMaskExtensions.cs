using UnityEngine;

namespace PocketApps.Utils {
    public static class LayerMaskExtensions {
        /// <summary> Checks whether mask contains the layer or not </summary>
        public static bool Contains(this LayerMask mask, int layer) {
            return (mask & (1 << layer)) != 0;
        }

        public static LayerMask With(this LayerMask mask, int layer) {
            return mask | (1 << layer);
        }

        public static LayerMask Without(this LayerMask mask, int layer) {
            return mask & ~(1 << layer);
        }
    }
}

