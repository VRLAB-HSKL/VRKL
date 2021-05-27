//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Fly bietet eine Fortbewegung, in der 
    /// die Fortbewegung in allen drei Weltkoordiantenachsen
    /// möglich ist.
    /// </summary>
    public class Fly : Locomotion
    {
        /// <summary>
        /// Geschwindigkeit für die Bewegung der Kamera in km/h
        /// </summary>
        [Tooltip("Geschwindigkeit in km/h")]
        [Range(0.1f, 10.0f)]
        public float TheSpeed = 5.0f;

        /// <summary>
        /// Axis für das Input-System von Unity, mit der wir die
        /// Orientierung für die Flugrichtung in x und z manipulieren.
        /// </summary>
        [Tooltip("Axis für die Manipulation der Flugrichtung in xz\nSinnvolle Werte: Mouse X, Horizontal")]
        public string FlyAxisXZ = "Mouse X";

        /// <summary>
        /// Axis für das Input-System von Unity, mit der wir die
        /// Orientierung für die Flugrichtung in y manipulieren.
        /// </summary>
        [Tooltip("Axis für die Manipulation der Flugrichtung in y\nSinnvolle Werte: Mouse Y, Vertical")]
        public string FlyAxisY = "Mouse Y";

        /// <summary>
        /// Multiplikator für die Mausbewegung
        /// </summary>
        [Tooltip("Multiplikator für die Mausbewegung")]
        [Range(0.1f, 10.0f)]
        public float MouseSensitivity = 0.5f;

        /// <summary>
        /// Setzen der Flugrichtung.
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
            this.Direction = transform.forward;
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
            this.Speed = ReverseFactor * TheSpeed/3.6f;
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
            delta.y = MouseSensitivity * Input.GetAxis(FlyAxisXZ);
            delta.x = - MouseSensitivity * Input.GetAxis(FlyAxisY);
            Orientation = transform.eulerAngles + delta;
        }

    }
}