﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spaceworks {

    [System.Serializable]
    public class Vector3d {
        public double x;
        public double y;
        public double z;

        /// <summary>
        /// Convert double precision vector to single precision
        /// </summary>
        public Vector3 vector3 {
            get {
                return new Vector3((float)x, (float)y, (float)z);
            }
        }

        /// <summary>
        /// Length of the vector
        /// </summary>
        public double magnitude {
            get {
                return System.Math.Sqrt(this.sqrMagnitude);
            }
        }

        /// <summary>
        /// Squared length
        /// </summary>
        public double sqrMagnitude {
            get {
                return x * x + y * y + z * z;
            }
        }

        /// <summary>
        /// Vector with same direction of unit length
        /// </summary>
        public Vector3d normalized {
            get {
                double m = 1 / this.magnitude;
                return new Vector3d(x * m, y * m, z * m);
            }
        }

        /// <summary>
        /// Construct vector from components
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3d(double x = 0, double y = 0, double z = 0) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Construct vector from lower precision vector
        /// </summary>
        /// <param name="vec"></param>
        public Vector3d(Vector3 vec) {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }

        /// <summary>
        /// Copy a double precision vector
        /// </summary>
        /// <param name="other"></param>
        public Vector3d(Vector3d other) {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3d Cross(Vector3d u, Vector3d v) {
            return new Vector3d(
                u.y * v.z - u.z * v.y,
                u.z * v.x - u.x * v.z,
                u.x * v.y - u.y * v.x
            );
        }

        /// <summary>
        /// Dot product of two vectors
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static double Dot(Vector3d u, Vector3d v) {
            return u.x * v.x + u.y * v.y + u.z * v.z;
        }

        /// <summary>
        /// Rotate a vector about a normal by a given angle
        /// </summary>
        /// <param name="v">vector to rotate</param>
        /// <param name="rad">angle in radians</param>
        /// <param name="n">normal vector</param>
        /// <returns></returns>
        public static Vector3d Rotate(Vector3d v, double rad, Vector3d n) {
            double cos = System.Math.Cos(rad);
            double sin = System.Math.Sin(rad);

            double oneMinusCos = 1 - cos;

            double a11 = oneMinusCos * n.x * n.x + cos;
            double a12 = oneMinusCos * n.x * n.y - n.z * sin;
            double a13 = oneMinusCos * n.x * n.z + n.y * sin;
            double a21 = oneMinusCos * n.x * n.y + n.z * sin;
            double a22 = oneMinusCos * n.y * n.y + cos;
            double a23 = oneMinusCos * n.y * n.z - n.x * sin;
            double a31 = oneMinusCos * n.x * n.z - n.y * sin;
            double a32 = oneMinusCos * n.y * n.z + n.x * sin;
            double a33 = oneMinusCos * n.z * n.z + cos;

            return new Vector3d(
                v.x * a11 + v.y * a12 + v.z * a13,
                v.x * a21 + v.y * a22 + v.z * a23,
                v.x * a31 + v.y * a32 + v.z * a33
            );
        }

        #region operators

        //+
        public static Vector3d operator +(Vector3d a, Vector3d b) {
            return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3d operator +(Vector3 a, Vector3d b) {
            return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3d operator +(Vector3d a, Vector3 b) {
            return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        //-
        public static Vector3d operator -(Vector3d a, Vector3d b) {
            return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3d operator -(Vector3 a, Vector3d b) {
            return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3d operator -(Vector3d a, Vector3 b) {
            return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        //*
        public static Vector3d operator *(double a, Vector3d v) {
            return new Vector3d(a * v.x, a * v.y, a * v.z);
        }

        public static Vector3d operator *(Vector3d v, double a) {
            return new Vector3d(a * v.x, a * v.y, a * v.z);
        }

        //==
        public static bool operator ==(Vector3d a, Vector3d b) {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Vector3d a, Vector3d b) {
            return !(a == b);
        }

        public override bool Equals(object obj) {
            if (obj is Vector3d) {
                return this == (Vector3d)obj;
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        #endregion
    }


}
