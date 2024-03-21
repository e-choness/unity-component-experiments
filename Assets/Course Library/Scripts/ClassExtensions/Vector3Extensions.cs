﻿using UnityEngine;

namespace Course_Library.Scripts.ClassExtensions
{
    public static class Vector3Extensions
    {
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(vector.x + (x ?? 0.0f), vector.y + (y ?? 0.0f), vector.z + (z ?? 0.0f));
        }

        public static Vector2 ToVector2WithY(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
        public static Vector2 ToVector2WithZ(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }
    }
}