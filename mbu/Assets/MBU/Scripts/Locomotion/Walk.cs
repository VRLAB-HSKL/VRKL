//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Walk bietet eine Fortbewegung, in der ausschließlich
    /// die x- und z-Koordinate der Kamera verändert werden.
    /// </summary>
    public class Walk : Locomotion
    {
        /// <summary>
        /// Geschwindigkeit für die Bewegung der Kamera in km/h
        /// </summary>
        [Tooltip("Geschwindigkeit in km/h")]
        [Range(0.1f, 10.0f)]
        public float TheSpeed = 5.0f;

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
        /// Setzen der Laufrichtung.
        /// <remark>
        /// Die Laufrichtung verwendet die Achse transform.forward
        /// der Kamera.
        /// 
        /// Diese Achse wird mit Hilfe der Eulerwinkel, die in
        /// MovementOrientation manipuliert wird verändert.
        /// </remark>
        /// </summary>
        protected override void MovementDirection()
        {
            Direction = transform.forward;
        }

        /// <summary>
        /// Berechnung der Geschwindigkeit der Fortbewegung
        /// </summary>
        /// <remarks>
        /// Wir rechnen die km/h aus dem Interface in m/s um.
        /// </remarks>
        /// <returns></returns>
        protected override void MovementSpeed()
        {
            Speed = ReverseFactor * TheSpeed/3.6f;
        }

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
        protected override void MovementOrientation()
        {
            Vector3 delta = new Vector3(0.0f, 0.0f, 0.0f);
            delta.y = MouseSensitivity * Input.GetAxis(WalkAxis);
            Orientation = transform.eulerAngles + delta;
        }

    }
}