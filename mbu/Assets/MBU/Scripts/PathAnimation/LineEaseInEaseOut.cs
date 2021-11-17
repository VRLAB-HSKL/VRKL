//========= 2021 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace für MBU
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Bewegung eines Objekts entlang einer Linie zwischen zwei Punkten.
    ///
    /// Wir verwenden das Hermite-Polynom H33 für einn Ease-In-Ease-Out Effekt. 
    /// </summary>
    public class LineEaseInEaseOut : PathAnimation
    {
        /// <summary>
        /// Anfangspunkt
        /// </summary>
        [Tooltip("Anfangspunkt der Linie")]
        public Vector3 P1 = Vector3.zero;
        /// <summary>
        /// ZEndpunkt
        /// </summary>
        [Tooltip("Endpunkt der Linie")]
        public Vector3 P2 = Vector3.right;
        /// <summary>
        /// Bogenlänge der Linie
        /// </summary>
        private float arcL = 0.0f;
        /// <summary>
        ///  Richtungsvektor
        /// </summary>
        private Vector3 dirVec = Vector3.forward;
        /// <summary>
        /// Berechnung der Punkte für eine Linie zwischen P1 und P2.
        /// 
        /// Wir verwenden das Parameterintervall [0.0, L], dabei
        /// ist L der Abstand zwischen den beiden Punkten.
        /// 
        /// Damit können wir garantieren, dass die Linie nach
        /// Bogenmaß parametrisiert ist.
        /// </summary>
        protected override void ComputePath()
        {
            arcL = Vector3.Distance(P1, P2);
            dirVec = P2 - P1;
            waypoints = new Vector3[NumberOfPoints];
            velocities = new float[NumberOfPoints];
            var t = 0.0f;
            var delta = (1.0f) / ((float)NumberOfPoints - 1.0f);
            distance = 2.0f*arcL*delta;
            for (var i = 0; i < NumberOfPoints; i++)
            {
                waypoints[i] = P1 + H33(t) * dirVec;
                velocities[i] = H33prime(t);
                t += delta;
            }
        }

        /// <summary>
        /// Berechnung der ersten Lookat-Punkts. 
        /// Duie Tangente der Linie stimmt mit dem normierten Richtungsvektor
        /// überein.
        /// </summary>
        /// <returns>Punkt, der LookAt übergeben werden kann</returns>
        protected override Vector3 ComputeFirstLookAt()
        {
            return P2;
        }

        /// <summary>
        /// Hermite-Polynom H33.
        /// </summary>
        /// <param name="x">x-Wert</param>
        /// <returns>Wert des Hermite-Polynoms</returns>
        private float H33(float x)
        {
            return x*x*(3.0f - 2.0f*x);
        }
        
        /// <summary>
        /// Ableitung des Hermite-Polynoms H33.
        /// </summary>
        /// <param name="x">x-Wert</param>
        /// <returns>Wert de Ableitung des Hermite-Polynoms</returns>
        private float H33prime(float x)
        {
            return 6.0f*x*(1-x);
        }
    }
}