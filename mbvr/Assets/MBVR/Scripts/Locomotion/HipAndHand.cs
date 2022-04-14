//========= 2021 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;

namespace VRKL.MBVR
{
    /// <summary>
    /// Abstrakte Basisklasse für kontinuierliche Fortbewegung in immersiven Anwendungen,
    /// abgeleitet von ContinousMovement.
    /// 
    /// Abgeleitete Klassen berechnen die bewegungsrichtung aus der Differenz der Position
    /// von zwei GameObjects.
    /// 
    /// Eine Anwendung dafür sind insbesondere sogenannte "leaning models".
    /// </summary>
    public class HipAndHand : TwoObjectsDirection
    {
        /// <summary>
        /// Update der Orientierung des GameObjects,
        /// das die Bewegungsrichtung definiert..
        /// </summary>
        /// <remarks>
        /// Für die Verarbeitung der Orientierung verwenden wir
        /// die Eulerwinkel der x- und y-Achse.
        /// </remarks>
        protected override void UpdateOrientation()
        {
            //Orientation.y = orientationObject.transform.eulerAngles.y;
        }
    }
}

