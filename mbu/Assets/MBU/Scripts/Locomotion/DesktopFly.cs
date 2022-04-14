//========= 2020 - 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// DesktopFly bietet eine Fortbewegung, in der 
    /// die Fortbewegung in allen drei Weltkoordiantenachsen
    /// möglich ist.
    /// </summary>
    public class DesktopFly : DesktopLocomotion
    {
        [Header("Bewegungsrichtung")]
        [Tooltip("Axis für die Manipulation der Flugrichtung in y\nSinnvolle Werte: Mouse Y, Vertical")]
        /// <summary>
        /// Axis für das Input-System von Unity, mit der wir die
        /// Orientierung für die Flugrichtung in y manipulieren.
        /// </summary>
        public string FlyAxisY = "Mouse Y";
        
        /// <summary>
        /// Axis für das Input-System von Unity, mit der wir die
        /// Orientierung für die Flugrichtung in x und z manipulieren.
        /// </summary>
        [Tooltip("Axis für die Manipulation der Flugrichtung in xz\nSinnvolle Werte: Mouse X, Horizontal")]
        public string FlyAxisXZ = "Mouse X";
        
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
        /// Wir verwenden Eulerwinkel.
        /// </summary>
        /// <returns>
        /// Orientierungen als Instanz von Vector3.
        /// </returns>
        protected override void UpdateOrientation()
        {
            var delta = new Vector3(0.0f, 0.0f, 0.0f)
            {
                y =    MouseSensitivity * Input.GetAxis(FlyAxisXZ),
                x = - MouseSensitivity * Input.GetAxis(FlyAxisY)
            };
            Orientation = transform.eulerAngles + delta;
        }
    }
}