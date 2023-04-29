using UnityEngine;

namespace PocketApps.Utils {
    public static class LayerMaskExtensions {
        /// <summary> Checks whether mask contains the layer or not </summary>
        public static bool Contains(this LayerMask mask, int layer) {
            return (mask & (1 << layer)) != 0;
        }
    }
}

