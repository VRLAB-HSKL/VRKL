//========= 2021 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Abstrakte Basisklasse für immersive Locomotion-Verfahren,
    /// die ein Objekt
    /// für die Definition der Bewegungsrichtung einsetzen.
    /// </summary>
    public abstract class SingleObjectDirection : VRLocomotion
    {
        [Header("Definition der Bewegungsrichtung")]
        /// <summary>
        /// Welches GameObject verwenden wir für die Definition der Richtung?
        /// </summary>
        /// <remarks>
        /// Sinnvoll ist einer der beiden Controller, aber auch andere
        /// GameObjects (wie der Kopf oder ein Vive Tracker) können
        /// sinnvoll eingesetzt  werden.
        /// </remarks>

        [Tooltip("GameObject, das die Bewegungsrichtung definiert")]
        public GameObject orientationObject;
        
        
        /// <summary>
        /// Bewegungsrichtung auf den forward-Vektor des Orientierungsobjekts setzen.
        /// </summary>
        protected override void InitializeDirection()
        {
            Direction = orientationObject.transform.forward;
        }
    }
}

