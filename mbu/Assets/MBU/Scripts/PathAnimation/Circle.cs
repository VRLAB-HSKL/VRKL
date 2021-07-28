//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace für allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Bewegung eines Objekts entlang eines Kreise
    /// </summary>
    public class Circle : PathAnimation
    {
        /// <summary>
        /// Radius des Kreises
        /// </summary>
        [Range(3.0f, 12.0f)]
        [Tooltip("Radius")]
        public float Radius = 6.0f;


        /// <summary>
        /// Berechnung der Punkte für einen Kreise mit Mittelpunkt im Ursprung
        /// 
        /// Wir verwenden das Parameterintervall [0.0, 2.0*pi].
        /// </summary>
        protected override void ComputePath()
        {
            waypoints = new Vector3[NumberOfPoints];
            float x = 0.0f;
            float delta = (2.0f * Mathf.PI) / (float)NumberOfPoints;

            for (int i = 0; i < NumberOfPoints; i++)
            {
                waypoints[i].x = Radius * Mathf.Cos(x);
                waypoints[i].y = 0.0f;
                waypoints[i].z = Radius * Mathf.Sin(x);
                x += delta;
            }
        }

        /// <summary>
        /// Berechnung der ersten Lookat-Punkts. 
        /// Wir berechnen die Tangente am ersten Punkt des Kreises
        /// und berechnen einen Punkt auf der Gerade durch ersten Zielpunkt
        /// mit Richtungsvektor Tangente als ersten Lookat-Punkt.
        /// 
        /// Wir verwenden nicht den Geschwindigkeitsvektor für die Berechnung,
        /// da wir aktuell davon ausgehen, dass wir beim Parameterwert a=0 starten.
        /// Dann ist die erste Orientierung durch forward, die z-Achse,
        /// gegeben.
        /// </summary>
        /// <returns>Punkt, der LookAt übergeben werden kann</returns>
        protected override Vector3 ComputeFirstLookAt()
        {
            return new Vector3(0.0f, 0.0f, 1.0f);
        }
    }
}
