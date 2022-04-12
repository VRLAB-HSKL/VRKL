//========= 2020 - 2022 - Copyright Manfred Brill. All rights reserved. ===========
using System;
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Abstrakte Basisklasse für die Fortbewegung (Locomotion)
    /// in einer Unity-Szene. Ziel sind hier Desktop- oder Android-
    /// Anwendungen, keine XR-Anwendung!
    /// 
    /// Für die Locomotion verwenden wir immer zwei Variablen:
    /// - einen Richtungsvektor (mit euklidischer Länge 1)
    /// - einen Skalar.
    /// 
    /// Diese beiden Variablen definieren die Veränderung der Position
    /// der Kamera.
    /// 
    /// Häufig werden auch die Euler-Winkel der beeinflussten Kamera verändert.
    /// 
    /// Wie diese Variablen verändert werden wird in den Klassen
    /// realisiert, die von dieser Basisklasse abgeleitet werden.
    /// 
    /// <remark>
    /// Mit RequireComponent wird sicher gestellt, dass diese Klasse und
    /// die, die davon abgeleitet werden,
    /// nur GameObjects hinzugefügt werden können, die eine Camera-Komponente besitzen.
    /// </remark>
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public abstract class DesktopLocomotion : Locomotion
    {
        [Header("Device Interface")]
        /// <summary>
        /// Button, der die Fortbewegung auslöst.
        /// <remark>
        /// Wir verwenden die logischen Buttons des Input-Managers von Unity.
        /// In den Preferences des input-Managers kann nachgesehen werden welche
        /// Keyboard-Tasten hier als Ersatz verwendet werden.
        /// </remark>
        /// </summary>
        [Tooltip("Button das Auslösen der Bewegung\nSinnvolle Werte: Fire1, Fire2, Fire3, Submit, Jump")]
        public string TriggerButton = "Fire1";

        /// <summary>
        /// Button, der die Bewegungsrichtung um 180 Grad dreht ("Rückwärtsgang").
        /// <remark>
        /// Wir verwenden die logischen Buttons des Input-Managers von Unity.
        /// In den Preferences des input-Managers kann nachgesehen werden welche
        /// Keyboard-Tasten hier als Ersatz verwendet werden.
        /// </remark>
        /// </summary>
        public string ReverseButton = "Submit";

        [Header("Anfangsgeschwindigkeit")]
        /// <summary>
        /// Geschwindigkeit für die Bewegung der Kamera in km/h
        /// </summary>
        [Tooltip("Geschwindigkeit")]
        [Range(0.1f, 20.0f)]
        public float TheSpeed = 5.0f; 
        
        /// <summary>
        /// Maximal mögliche Geschwindigkeit
        /// </summary>
        [Tooltip("Maximal mögliche Bahngeschwindigkeit")]
        [Range(0.001f, 20.0f)]
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
        /// Wir rechnen die km/h aus dem Interface durch Division
        /// mit 3.6f in m/s um.
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
        /// Initialisieren
        /// </summary>
        protected virtual void Awake()
        {
            // Bewegungsrichtung, Orientierung und Bahngeschwindigkeit initialisieren
            MovementDirection();
            InitializeOrientation();
            InitializeVelocity();
        }

        /// <summary>
        /// Update aufrufen und die Bewegung ausführen.
        /// </summary>
        protected virtual void Update()
        {
            MovementDirection();
            MovementSpeed();
            // Orientierung auch verändern wenn die Bewegung nicht ausgeführt wird!
            MovementOrientation();
            transform.eulerAngles = Orientation;

            if (Input.GetButtonDown(ReverseButton))
            {
                ReverseFactor *= -1.0f;
            }

            if (Input.GetButton(TriggerButton))
                Move();
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