//========= 2020 - 2022 - Copyright Manfred Brill. All rights reserved. ===========

using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

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
    public abstract class Locomotion : MonoBehaviour
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
        
        /// <summary>
        /// Multiplikator, um die Bewegungsrichtung um 180 Grad drehen zu können.
        /// </summary>
        protected float ReverseFactor = 1.0f;

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
        /// Bewegung durchführen
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
            {
                transform.Translate(Speed * Time.deltaTime * Direction);
            }
        }

        /// <summary>
        /// Betrag derGeschwindigkeit für die Bewegung
        /// <remark>
        /// Einheit dieser Variable ist m/s.
        /// </remark>
        /// </summary>
        protected float Speed;
        /// <summary>
        /// Normierter Richtungsvektor für die Fortbewegung.
        /// </summary>
        protected Vector3 Direction;
        /// <summary>
        /// Vektor mit den Eulerwinkeln für die Kamera
        /// </summary>
        protected Vector3 Orientation;

        /// <summary>
        /// Festlegen der Bewegungsrichtung.
        /// </summary>
        /// <remark>
        /// Bewegungsrichtung als normalisierte Vector3-Instanz.
        /// Wenn diese Funktion nicht überschrieben wird verwenden
        /// wir forward des GameObjects, an dem die Komponente
        /// hängt.
        /// </remark>
        protected virtual void MovementDirection()
        {
            Direction = transform.forward;
        }
        /// <summary>
        /// Berechnung der Geschwindigkeit der Fortbewegung
        /// </summary>
        protected abstract void MovementSpeed();
        /// <summary>
        /// Orientierung für die Bewegung als Eulerwinkel.
        /// </summary>
        /// <remark>
        /// Orientierungen als Instanz von Vector3.
        /// </remark>
        protected abstract void MovementOrientation();

        /// <summary>
        /// Orientierung initialiseren. Wir überschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktionin Locomotion::Awake auf.
        /// </summary>
        protected virtual void InitializeOrientation()
        {
            Orientation = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
        /// <summary>
        /// Geschwindigkeit initialiseren. Wir überschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktionin Locomotion::Awake auf.
        /// </summary>
        protected abstract void InitializeVelocity();
        
        /// <summary>
        /// Klasse für die Verwaltung der Bahngeschwindigkeit.
        /// </summary>
        protected ScalarProvider Velocity;
    }
}