//========= 2021 - 2022 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Walk als Locomotion in einer VR-Anwendung. 
    /// </summary>
    /// <remarks>
    /// Für Walk verändern wir nur die Orientierung in der xz-Achse.
    ///
    /// Wir verwenden einen Trigger-Button. So lange dieser Button
    /// gedrückt ist wird die Bewegung ausgeführt.
    /// 
    /// Als Bewegungsrichtung verwenden wir die Orientierung
    /// eines GameObjects, typischer Weise eines der Controllert.
    ///
    /// Die Geschwindigkeit wird mit Buttons auf einem Controller
    /// verändert.
    /// </remarks>
    public class Walk : SingleObjectDirection
    {
        /// <summary>
        /// Bewegungsrichtung auf den forward-Vektor des Orientierungsobjekts setzen.
        /// </summary>
        protected override void UpdateDirection()
        {
            Direction = orientationObject.transform.forward;
            Direction.y = 0.0f;
            Direction.Normalize();
        }
        
        /// <summary>
        /// Update der Orientierung des GameObjects,
        /// das die Bewegungsrichtung definiert..
        /// </summary>
        /// <remarks>
        /// Für die Verarbeitung der Orientierung verwenden wir
        /// die Eulerwinkel der x- und y-Achse.
        ///
        /// Wird aktuell nicht verwendet, da wir die Bewegungsrichtung
        /// direkt aus dem forward-Vektor des Orientierungsobjekts
        /// ablesen.
        /// </remarks>
        protected override void UpdateOrientation()
        {
            throw new System.NotImplementedException();
        }
    }
}
