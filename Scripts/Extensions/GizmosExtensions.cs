using UnityEngine;

public static class GizmosExtensions {
    public static void DrawSquareXZ(Vector3 center, float sideLength) {
        var halfSideLength = sideLength * 0.5f;
        var tl = center + new Vector3(-halfSideLength, 0, -halfSideLength);
        var tr = center + new Vector3(halfSideLength, 0,  -halfSideLength);
        var bl = center + new Vector3(- halfSideLength, 0, halfSideLength);
        var br = center + new Vector3(halfSideLength, 0, halfSideLength);

        Gizmos.DrawLine(tl, tr);
        Gizmos.DrawLine(tr, br);
        Gizmos.DrawLine(br, bl);
        Gizmos.DrawLine(bl, tl);
    }

    public static void DrawCircleXZ(Vector3 center, float radius, int segments) {
        if (radius <= 0.0f || segments <= 0) {
            return;
        }

        float angleStep = (Mathf.PI * 2) / (float)segments;

        Vector3 lineStart = Vector3.zero;
        Vector3 lineEnd = Vector3.zero;

        for (int i = 0; i < segments; i++) {
            lineStart.x = Mathf.Cos(angleStep * i);
            lineStart.z = Mathf.Sin(angleStep * i);
            lineStart.y = 0;

            lineEnd.x = Mathf.Cos(angleStep * (i + 1));
            lineEnd.z = Mathf.Sin(angleStep * (i + 1));
            lineEnd.y = 0;

            lineStart = center + lineStart * radius;
            lineEnd = center + lineEnd * radius;

            Gizmos.DrawLine(lineStart, lineEnd);
        }
    }
}