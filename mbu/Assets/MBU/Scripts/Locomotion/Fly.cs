//========= 2020 - 2022 - Copyright Manfred Brill. All rights reserved. ===========
using System;
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
        [Header("Bewegungsrichtung")]
        /// <summary>
        /// Axis für das Input-System von Unity, mit der wir die
        /// Orientierung für die Flugrichtung in y manipulieren.
        /// </summary>
        [Tooltip("Axis für die Manipulation der Flugrichtung in y\nSinnvolle Werte: Mouse Y, Vertical")]
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
        
        [Header("Anfangsgeschwindigkeit")]
        /// <summary>
        /// Geschwindigkeit für die Bewegung der Kamera in km/h
        /// </summary>
        [Tooltip("Geschwindigkeit")]
        [RangeAttribute(0.1f, 20.0f)]
        public float TheSpeed = 5.0f; 
        
        /// <summary>
        /// Maximal mögliche Geschwindigkeit
        /// </summary>
        [Tooltip("Maximal mögliche Bahngeschwindigkeit")]
        [RangeAttribute(0.001f, 20.0f)]
        public float vMax = 10.0f;

        /// <summary>
        /// Delta für das Verändern der Geschwindigkeit
        /// </summary>
        [Tooltip("Delta für die Veränderung der Bahngeschwindigkeit")]
        [Range(0.001f, 2.0f)]
        public float vDelta = 0.2f;
        /// <summary>
        /// Taste  für das Abbremsen der Fortbewegung.
        /// Default ist "D"
        /// </summary>
        [Tooltip("Taste für das Abbremsen")] 
        public String DecKey= "d";

        /// <summary>
        /// Taste  für das Beschleunigen der Fortbewegung.
        /// Default ist "A"
        /// </summary>
        [Tooltip("Taste für das Abbremsen")] 
        public string AccKey = "a";
        
        /// <summary>
        /// Berechnung der Geschwindigkeit der Fortbewegung
        /// </summary>
        /// <remarks>
        /// Wir rechnen die km/h aus dem Interface in m/s um.
        /// </remarks>
        /// <returns></returns>
        protected override void MovementSpeed()
        {
            if (Input.GetKeyUp(AccKey))
                _speed.Increase();
            if (Input.GetKeyUp(DecKey))
                _speed.Decrease();
            Speed = ReverseFactor * _speed.value/3.6f;
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
            var delta = new Vector3(0.0f, 0.0f, 0.0f)
            {
                y =    MouseSensitivity * Input.GetAxis(FlyAxisXZ),
                x = - MouseSensitivity * Input.GetAxis(FlyAxisY)
            };
            Orientation = transform.eulerAngles + delta;
        }

        /// <summary>
        /// Geschwindigkeit initialiseren. Wir überschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktionin Locomotion::Awake auf.
        /// </summary>
        protected override void InitializeVelocity()
        {
            _speed = new ScalarProvider(TheSpeed, vDelta, 0.0f, vMax);
            Speed = _speed.value;
        }

        private ScalarProvider _speed;
    }
}