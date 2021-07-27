//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace f�r allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Bewegung eines Objekts entlang eines Kreises
    /// </summary>
    public class Ellipse : PathAnimation
    {
        /// <summary>
        /// Erste Halbachse a der Ellipse
        /// </summary>
        [Range(3.0f, 12.0f)]
        [Tooltip("Erste Halbache der Ellipse")]
        public float RadiusA = 6.0f;
        /// <summary>
        /// Erste Halbachse a der Ellipse
        /// </summary>
        [Range(3.0f, 12.0f)]
        [Tooltip("Zweite Halbache der Ellipse")]
        public float RadiusB = 6.0f;

        /// <summary>
        /// Berechnung der Punkte f�r eine Ellipse mit Brennpunkt im Ursprung
        /// </summary>
        protected override void ComputePath()
        {
            waypoints = new Vector3[NumberOfPoints];
            float x = 0.0f;
            float delta = (2.0f * Mathf.PI) / (float)NumberOfPoints;
            for (int i = 0; i < NumberOfPoints; i++)
            {
                waypoints[i].x = RadiusA * Mathf.Cos(x);
                waypoints[i].y = 0.0f;
                waypoints[i].z = RadiusB * Mathf.Sin(x);
                x += delta;
            }
        }
    }
}
