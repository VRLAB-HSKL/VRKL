//========= 2021 - 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Abstrakte Basisklasse für die Realisierung von Locomotion-Verfahren,
    /// die die Differenz zweier Objekte
    /// für die Definition der Bewegungsrichtung verwenden.
    /// </summary>
    /// <remarks>
    ///Der Differenzvektor wird normalisiert.
    /// </remarks>
    public abstract class TwoObjectsDirection : VRLocomotion
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
        [Tooltip("GameObject, das den Endpunkt der Bewegungsrichtung definiert")]
        public GameObject endObject;

        /// <summary>
        /// Bewegungsrichtung als Differenz der forward-Vektoren
        /// der beiden definierenden Objekte setzen.
        /// </summary>
        protected override void InitializeDirection()
        {
            Direction = endObject.transform.position-startObject.transform.position;
            Direction.Normalize();
        }
    }
}

