#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using JigLibX.Utils;
using JigLibOpenTK;
#endregion

namespace JigLibX.Math
{
    /// <summary>
    /// Class JiggleMath
    /// </summary>
    public static class JiggleMath
    {
        /// <summary>
        /// 1.0e-6f
        /// </summary>
        public const float Epsilon = 1.0e-6f;

        /// <summary>
        /// Wrap
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>float</returns>
        public static float Wrap(float val, float min, float max)
        {
            float delta = max - min;
            if (val > delta)
            {
                val = val / delta;
                val = val - (float)System.Math.Floor(val);
                val = val * delta;
            }
            return val;
        }

        /// <summary>
        /// SafeInvScalar
        /// </summary>
        /// <param name="val"></param>
        /// <returns>float</returns>
        public static float SafeInvScalar(float val)
        {
            if (System.Math.Abs(val) < JiggleMath.Epsilon) return float.MaxValue;
            return 1.0f / val;
        }

        /// <summary>
        /// NormalizeSafe
        /// </summary>
        /// <param name="vec"></param>
        public static void NormalizeSafe(ref Vector3 vec)
        {
            float num0 = vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z;

            if (num0 != 0.0f)
            {
                float num1 = 1.0f / (float)System.Math.Sqrt(num0);
                vec.X *= num1; vec.Y *= num1; vec.Z *= num1;
            }
        }

        /// <summary>
        /// NormalizeSafe
        /// </summary>
        /// <param name="vec"></param>
        /// <returns>Vector3</returns>
        public static Vector3 NormalizeSafe(Vector3 vec)
        {
            float num0 = vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z;

            if (num0 != 0.0f)
            {
                float num1 = 1.0f / (float)System.Math.Sqrt(num0);
                vec.X *= num1;vec.Y *= num1;vec.Z *= num1;
            }

            return vec;
        }

        /// <summary>
        /// Orthonormalise
        /// </summary>
        /// <param name="matrix"></param>
        public static void Orthonormalise(ref Matrix4 matrix)
        {
            float u11 = matrix.M11;float u12 = matrix.M12;float u13 = matrix.M13;
            float u21 = matrix.M21;float u22 = matrix.M22;float u23 = matrix.M23;
            float u31 = matrix.M31;float u32 = matrix.M32;float u33 = matrix.M33;

            float dot0,dot1;

            // u1
            float lengthSq0 = u11 * u11 + u12 * u12 + u13 * u13;
            float length0 = (float)System.Math.Sqrt(lengthSq0);
            u11 = u11 / length0;
            u12 = u12 / length0;
            u13 = u13 / length0;

            // u2
            dot0 = u11 * u21 + u12 * u22 + u13 * u23;
            u21 = u21 - dot0 * u11 / lengthSq0;
            u22 = u22 - dot0 * u12 / lengthSq0;
            u23 = u23 - dot0 * u13 / lengthSq0;

            float lengthSq1 = u21 * u21 + u22 * u22 + u23 * u23;
            float length1 = (float)System.Math.Sqrt(lengthSq1);
            u21 = u21 / length1;
            u22 = u22 / length1;
            u23 = u23 / length1;

            // u3
            dot0 = u11 * u31 + u12 * u32 + u13 * u33;
            dot1 = u21 * u31 + u22 * u32 + u23 * u33;
            u31 = u31 - dot0 * u11 / lengthSq0 - dot1 * u21 / lengthSq1;
            u32 = u32 - dot0 * u12 / lengthSq0 - dot1 * u22 / lengthSq1;
            u33 = u33 - dot0 * u13 / lengthSq0 - dot1 * u23 / lengthSq1;

            lengthSq0 = u31 * u31 + u32 * u32 + u33 * u33;
            length0 = (float)System.Math.Sqrt(lengthSq0);
            u31 = u31 / length0;
            u32 = u32 / length0;
            u33 = u33 / length0;

            matrix.M11 = u11;matrix.M12 = u12;matrix.M13 = u13;
            matrix.M21 = u21;matrix.M22 = u22;matrix.M23 = u23;
            matrix.M31 = u31;matrix.M32 = u32;matrix.M33 = u33;      
        }

        /// <summary>
        /// Assumes dir is normalised. Angle is in degrees.
        /// </summary>
        /// <param name="ang"></param>
        /// <param name="dir"></param>
        /// <returns>Matrix4</returns>
        public static Matrix4 RotationMatrix(float ang, Vector3 dir)
        {
            return Matrix4.CreateFromAxisAngle(dir, OpenTKHelper.ToRadians(ang));
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>float</returns>
        public static float Max(float a, float b, float c) 
        {
            float abMax = a > b ? a : b;

            return abMax > c ? abMax : c;
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>float</returns>
        public static float Min(float a, float b, float c)
        {
            float abMin = a < b ? a : b;

            return abMin < c ? abMin : c;
        }

    }
}
