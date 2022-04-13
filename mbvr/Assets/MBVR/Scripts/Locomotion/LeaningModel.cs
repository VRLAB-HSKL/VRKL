//========= 2021 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Abstrakte Basisklasse für die Realisierung von Learning Models und
    /// anderen Locomotion-Verfahren, die die Differenz zweier Objekte
    /// für die Definition der Bewegungsrichtung verwenden.
    /// </summary>
    public abstract class LeaningModel : VRLocomotion
    {
        [Header("Definition der Bewegungsrichtung durch zwei GameObjects")]
        /// <summary>
        /// GameObject, das den Startpunkt der Bewegungsrichtung definiert
        /// </summary>
        [Tooltip("GameObject, das den Startpunkt der Bewegungsrichtung definiert")]
        public GameObject startObject;

        /// <summary>
        /// GameObject, das den Endpunkt der Bewegungsrichtung definiert
        /// </summary>
        [Tooltip("GameObject, das den Startpunkt der Bewegungsrichtung definiert")]
        public GameObject endObject;

        /// <summary>
        /// Berechnung der Orientierung aus den zwei GameObjects
        /// </summary>
        /// <remarks>
        /// In den konkreten Implementierungen implementieren wir
        /// die Funktion UpdateOrientation.
        ///
        /// Die Definition der Bewegungsrichtung ist dort durch zwei Euler-Winkel
        /// gegeben, die wir hier berechnen.
        /// </remarks>
        protected void ComputeMovingDirection()
        {
            var startingPoint = startObject.transform.position;
            var endPoint = endObject.transform.position;

            var movingDirection = endPoint - startingPoint;
            movingDirection.Normalize();

        }
    }
}

