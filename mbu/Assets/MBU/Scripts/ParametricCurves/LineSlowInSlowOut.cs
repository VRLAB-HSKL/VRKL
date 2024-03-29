//========= 2021 - 2024 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Bewegung eines Objekts entlang einer Linie zwischen zwei Punkten.
    ///
    /// Wir verwenden das Hermite-Polynom H33 f�r einn Ease-In-Ease-Out Effekt. 
    /// </summary>
    public class LineSlowInSlowOut : SlowInSlowOut
    {
        /// <summary>
        /// Anfangspunkt
        /// </summary>
        [Tooltip("Anfangspunkt der Linie")] public Vector3 p1 = Vector3.zero;

        /// <summary>
        /// ZEndpunkt
        /// </summary>
        [Tooltip("Endpunkt der Linie")] public Vector3 p2 = Vector3.right;

        /// <summary>
        /// Bogenl�nge der Linie
        /// </summary>
        private float _arcL = 0.0f;

        /// <summary>
        ///  Richtungsvektor
        /// </summary>
        private Vector3 _dirVec = Vector3.zero;

        /// <summary>
        /// Berechnung der Punkte f�r eine Linie zwischen P1 und P2.
        /// 
        /// Wir verwenden das Parameterintervall [0.0, L], dabei
        /// ist L der Abstand zwischen den beiden Punkten.
        /// Der Richtungsvektor f�r diese Parametrisierung ist
        /// der normierte Vektor _dirVec. Das kompensieren wir im Code
        /// und denken direkt in t aus dem Intervall [0, 1] und normieren
        /// den Vektor nicht.
        /// 
        /// Damit k�nnen wir garantieren, dass die Linie nach
        /// Bogenma� parametrisiert ist.
        /// </summary>
        protected override void ComputePath()
        {
            _arcL = Vector3.Distance(p1, p2);
            _dirVec = p2 - p1;
            waypoints = new Vector3[NumberOfPoints];
            velocities = new float[NumberOfPoints];
            var t = 0.0f;
            var delta = (1.0f) / ((float) NumberOfPoints - 1.0f);
            for (var i = 0; i < NumberOfPoints; i++)
            {
                waypoints[i] = p1 + H33(t) * _dirVec;
                velocities[i] = H33Prime(t);
                t += delta;
            }
        }

        /// <summary>
        /// Berechnung der ersten Lookat-Punkts. 
        /// Die Tangente der Linie stimmt mit dem normierten Richtungsvektor
        /// �berein.
        /// </summary>
        /// <returns>Punkt, der LookAt �bergeben werden kann</returns>
        protected override Vector3 ComputeFirstLookAt()
        {
            return p2;
        }
    }
}