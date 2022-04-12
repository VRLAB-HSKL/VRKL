//========= 2020 - 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Abstrakte Basisklasse f�r die Fortbewegung auf dem Desktop
    /// und in VR.
    /// Davon abgeleitet gibt es die ebenfalls virtuellen Klassen
    /// MBU.Locomotion  und MBVR.ImmersiveLocomotion.
    /// </summary>
    public abstract class Locomotion : MonoBehaviour
    {
        /// <summary>
        /// Festlegen der Bewegungsrichtung.
        /// </summary>
        /// <remark>
        /// Bewegungsrichtung als normalisierte Vector3-Instanz.
        /// Wenn diese Funktion nicht �berschrieben wird verwenden
        /// wir forward des GameObjects, an dem die Komponente
        /// h�ngt.
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
        /// Orientierung f�r die Bewegung als Eulerwinkel.
        /// </summary>
        /// <remark>
        /// Orientierungen als Instanz von Vector3.
        /// </remark>
        protected abstract void MovementOrientation();

        /// <summary>
        /// Orientierung initialiseren. Wir �berschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktionin Locomotion::Awake auf.
        /// </summary>
        protected virtual void InitializeOrientation()
        {
            Orientation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        /// <summary>
        /// Geschwindigkeit initialiseren. Wir �berschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktionin Locomotion::Awake auf.
        /// </summary>
        protected abstract void InitializeVelocity();

        /// <summary>
        /// Multiplikator, um die Bewegungsrichtung um 180 Grad drehen zu k�nnen.
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
        
        protected virtual void Move()
        {
            transform.Translate(Speed * Time.deltaTime * Direction);
        }

        /// <summary>
        /// Betrag der Geschwindigkeit f�r die Bewegung
        /// <remark>
        /// Einheit dieser Variable ist m/s.
        /// </remark>
        /// </summary>
        protected float Speed;

        /// <summary>
        /// Normierter Richtungsvektor f�r die Fortbewegung.
        /// </summary>
        protected Vector3 Direction;

        /// <summary>
        /// Vektor mit den Eulerwinkeln f�r die Kamera
        /// </summary>
        protected Vector3 Orientation;

        /// <summary>
        /// Klasse f�r die Verwaltung der Bahngeschwindigkeit.
        /// </summary>
        protected ScalarProvider Velocity;
    }
}
