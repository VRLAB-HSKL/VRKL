//========= 2021 - Copyright Manfred Brill. All rights reserved. ===========
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
    public abstract class Locomotion : MonoBehaviour
    {
        /// <summary>
        /// Button, der die Fortbewegung auslöst.
        /// <remark>
        /// Wir verwenden die logischen Buttons des Input-Managers von Unity.
        /// In den Preferences des input-Managers kann nachgesehen werden welche
        /// Keyboard-Tasten hier als Ersatz verwendet werden.
        /// </remark>
        /// </summary>
        [Tooltip("Button das Auslösen der Bewegung\nSinnvolle Werte: Fire1, Fire2, Fire3, Submit, Jump")]
        public string TheTriggerButton = "Fire1";

        /// <summary>
        /// Button, der die Bewegungsrichtung um 180 Grad dreht ("Rückwärtsgang").
        /// <remark>
        /// Wir verwenden die logischen Buttons des Input-Managers von Unity.
        /// In den Preferences des input-Managers kann nachgesehen werden welche
        /// Keyboard-Tasten hier als Ersatz verwendet werden.
        /// </remark>
        /// </summary>
        [Tooltip("Button das Auslösen der Bewegung\nSinnvolle Werte: Fire1, Fire2, Fire3, Submit, Jump")]
        public string TheReverseButton = "Submit";
        
        /// <summary>
        /// Multiplikator, um die Bewegungsrichtung um 180 Grad drehen zu können.
        /// </summary>
        protected float ReverseFactor = 1.0f;

        /// <summary>
        /// Initialisieren
        /// </summary>
        protected virtual void Awake()
        {
            Speed = 1.0f;
            Direction = transform.forward;
        }

        /// <summary>
        /// Bewegung durchführen
        /// </summary>
        protected virtual void Update()
        {
            // Überprüfen, ob der Button für die Drehung der Richtung um 180 Grad ausgelöst wurde


            MovementDirection();
            MovementSpeed();
            // Orientierung auch verändern wenn die Bewegung nicht ausgeführt wird!
            MovementOrientation();
            transform.eulerAngles = Orientation;

            if (Input.GetButtonDown(TheReverseButton))
            {
                ReverseFactor *= -1.0f;
            }

            if (Input.GetButton(TheTriggerButton))
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
        /// Berechnung der Richtung der Fortbewegung
        /// </summary>
        /// <remark>
        /// Bewegungsrichtung als normalisierte Vector3-Instanz
        /// </remark>
        protected abstract void MovementDirection();
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

    }
}