namespace VUDK.Extensions.Gizmos
{
    using UnityEngine;

    public static class GizmosExtension
    {
        public static void DrawArrow(Vector3 from, Vector3 to, float size = 0.2f)
        {
            Vector3 direction = to - from;
            Vector3 arrowPoint = to - direction.normalized * 0.2f;

            Gizmos.DrawLine(from, arrowPoint);
            Gizmos.DrawLine(arrowPoint, arrowPoint + Quaternion.Euler(0, 160, 0) * direction.normalized * size);
            Gizmos.DrawLine(arrowPoint, arrowPoint + Quaternion.Euler(0, -160, 0) * direction.normalized * size);
        }
    }
}