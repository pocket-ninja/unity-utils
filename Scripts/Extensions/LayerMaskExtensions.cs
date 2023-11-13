using UnityEngine;

namespace PocketApps.Utils {
    public static class LayerMaskExtensions {
        /// <summary> Checks whether mask contains value </summary>
        public static bool ContainsValue(this LayerMask mask, int value) {
            return (mask & value) != 0;
        }

        /// <summary> Checks whether mask contains layer </summary>
        public static bool ContainsLayer(this LayerMask mask, int layer) {
            return mask.ContainsValue(1 << layer);
        }

        public static LayerMask WithValue(this LayerMask mask, int value) {
            return mask | value;
        }

        public static LayerMask WithLayer(this LayerMask mask, int layer) {
            return mask.WithValue(1 << layer);
        }
        
        public static LayerMask WithoutValue(this LayerMask mask, int value) {
            return mask & ~value;
        }

        public static LayerMask WithoutLayer(this LayerMask mask, int layer) {
            return mask.WithoutValue(1 << layer);
        }
    }
}

