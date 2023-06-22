namespace VUDK.Extensions.Vectors
{
    using UnityEngine;

    public static class Vector3Extension
    {
        public static float CalculateDistance(this Vector3 v1, Vector3 v2)
        {
            return Mathf.Sqrt(
                Mathf.Pow(v1.x - v2.x, 2) +
                Mathf.Pow(v1.y - v2.y, 2) +
                Mathf.Pow(v1.z - v2.z, 2)
                );
        }

        public static float Module(this Vector3 vector)
        {
            return Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2);
        }

        /// <summary>
        /// Sums to the coordinates of the vector a number.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="n">number to sum.</param>
        /// <returns>Vector2 summed with n.</returns>
        public static Vector2 Sum(this Vector3 vector, float n)
        {
            return new Vector2(vector.x + n, vector.y + n);
        }

        public static Vector3 Product(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        // THIS ALREADY EXIST, REMINDER TO DELETE THIS
        public static Vector3 CrossProduct(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }

        public static void Components(this Vector3 v1, out Vector3 vx, out Vector3 vy, out Vector3 vz)
        {
            vx = new Vector3(v1.x, 0, 0);
            vy = new Vector3(0, v1.y, 0);
            vz = new Vector3(0, 0, v1.z);
        }
    }
}