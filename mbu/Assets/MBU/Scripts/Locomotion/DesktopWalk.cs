//========= 2020 - 2022 - Copyright Manfred Brill. All rights reserved. ===========
using System;
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// DesktopWalk bietet eine Fortbewegung, in der ausschließlich
    /// die x- und z-Koordinate der Kamera verändert werden.
    /// </summary>
    public class DesktopWalk : DesktopLocomotion
    {
        [Header("Bewegungsrichtung")]
        /// <summary>
        /// Axis für das Input-System von Unity, mit der wir die
        /// Orientierung für die Laufrichtung manipulieren.
        /// </summary>
        [Tooltip("Axis für die Manipulation der Laufrichtung\nSinnvolle Werte: Mouse X, Horizontal")]
        public string WalkAxis = "Mouse X";
        
        /// <summary>
        /// Multiplikator für die Mausbewegung
        /// </summary>
        [Tooltip("Multiplikator für die Mausbewegung")]
        [Range(0.1f, 10.0f)]
        public float MouseSensitivity = 0.5f;
        
        /// <summary>
        /// Orientierung der Bewegung auf der Basis der Mausbewegung.
        /// 
        /// Die Mausbewegungen werden mit dem Dämpfungsfaktor multipliziert,
        /// um die Sensitivität zu steuern.
        /// 
        /// Wir verwenden Eulerwinkel, um die Bewegungsrichtung zu rotieren.
        /// </summary>
        /// <returns>
        /// Bewegungsrichtung als Instanz von Vector3.
        /// </returns>
        protected override void UpdateOrientation()
        {
            var delta = new Vector3(0.0f, 0.0f, 0.0f)
            {
                y = MouseSensitivity * Input.GetAxis(WalkAxis)
            };
            Orientation = transform.eulerAngles + delta;
        }
        
        /// <summary>
        /// Geschwindigkeit initialiseren. Wir überschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktionin Locomotion::Awake auf.
        /// </summary>
        protected override void InitializeOrientation()
        {
            Orientation = transform.eulerAngles;
        }
    }
}