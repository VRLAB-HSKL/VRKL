using UnityEngine;
using HTC.UnityPlugin.Vive;

namespace VRKL.MBVR
{
    /// <summary>
    /// Abstrakte Basisklasse für dien kontinuierliche Fortbewegung
    /// in immersiven Anwendungen auf der Basis von VIU.
    /// </summary>
    /// <remarks>
    /// Diese Klasse ist von VRKL.MBU.Locomotion abgeleitet.
    /// Dort sind bereits abstrakte Funktionen für die Fortbewegung
    /// vorgesehen, die wir in den abgeleiteten Klassen einsetzen.
    /// In der Basisklasse ist eine Variable ReverseButton vorgesehen,
    /// die aber in der VR-Version nicht verwendet wird. Das kann man noch tun,
    /// dann können wir einen Rückwärtsgang realisieren. Ob der wirklich
    /// gebraucht wird in VR sehen wir dann noch.
    ///
    /// In dieser Klasse kommen Geräte und Einstellungen für den
    /// Inspektor dazu.
    ///
    /// Mit RequireComponent wird sicher gestellt, dass das GameObject, dem
    /// wir diese Klasse hinzufügen einen CameraRig der Vive Input Utility
    /// enthält. Wir könnten auch nach dem Tag "MainCamera" suchen.
    /// </remarks>
    [RequireComponent(typeof(Camera))]
    public abstract class WalkingInPlace : VRKL.MBU.Locomotion
    {
        [Header("Trigger Device")]
        /// <summary>
        /// Welchen Controller verwenden wir für das Triggern der Fortbewegung?
        /// </summary>
        /// <remarks>
        /// Als Default verwenden wir den Controller in der rechten Hand,
        /// also "RightHand" im "ViveCameraRig".
        /// </remarks>
        [Tooltip("Welches GameObject bewegt sich, um die Bewegung zu triggern?")]
        public GameObject triggerObject;
  
        [Tooltip("Schwellwert für das Auslösen der Bewegung")]
        [Range(0.01f, 1.0f)]
        public float Threshold = 0.05f;
        
        [Header("Definition der Bewegungsrichtung")]
        /// <summary>
        /// Welches GameObject verwenden wir für die Definition der Richtung?
        /// </summary>
        /// <remarks>
        /// Sinnvoll ist bei Walking-in-Place der Kopf, oder irgend ein anderes
        /// getracktes GameObject.
        /// </remarks>

        [Tooltip("GameObject, das die Bewegungsrichtung definiert")]
        public GameObject orientationObject;
        
        [Header("Anfangsgeschwindigkeit")]
        /// <summary>
        /// Geschwindigkeit für die Bewegung der Kamera in km/h
        /// </summary>
        [Tooltip("Geschwindigkeit")]
        [Range(0.1f, 20.0f)]
        public float initialSpeed = 5.0f; 
        
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
        /// Bewegungsrichtung auf den forward-Vektor des Orientierungsobjekts setzen.
        /// </summary>
        protected override void InitializeDirection()
        {
            Direction = orientationObject.transform.forward;
        }
        
        /// <summary>
        /// Update aufrufen und die Bewegung ausführen.
        /// </summary>
        /// <remarks>
        ///Wir verwenden den forward-Vektor des
        /// Orientierungsobjekts als Bewegungsrichtung.
        ///
        /// Deshalb verwenden wir hier nicht die Funktion
        /// UpdateOrientation, sondern setzen die Bewegungsrichtung
        /// direkt.
        /// </remarks>
        protected virtual void Update()
        {
            UpdateDirection();
            UpdateSpeed();
            Trigger();
            Move();
        }

        /// <summary>
        /// Berechnung der Geschwindigkeit der Fortbewegung
        /// </summary>
        /// <remarks>
        /// Wir rechnen die km/h aus dem Interface durch Division
        /// mit 3.6f in m/s um.
        /// </remarks>
        protected override void UpdateSpeed()
        {
            Speed = Velocity.value/3.6f;
        }
        
        /// <summary>
        /// Geschwindigkeit initialiseren. Wir überschreiben diese
        /// Funktion in den abgeleiteten Klassen und rufen
        /// diese Funktion in Locomotion::Awake auf.
        /// </summary>
        protected override void InitializeSpeed()
        {
            Velocity = new VRKL.MBU.ScalarProvider(initialSpeed, vDelta, 
                                                                      0.0f, vMax);
            Speed = Velocity.value;
        }

        /// <summary>
        /// Walk wird so lange durchgeführt wie das Objekt bewegt wird.
        /// Das entscheiden wir auf Grund der Geschwindigkeit, die wir
        /// mit Hilfe von numerischem Differenzieren schätzen.
        /// </summary>
        protected virtual void Trigger()
        {
            // Velocity: numerisches Differenzieren
            float position = orientationObject.transform.position.y,
                vel = (position - lastValue) / Time.deltaTime;
            
            if ( Mathf.Abs(vel) > Threshold )
            {
                Moving = true;
            }
            else
            {
                Moving = false;
            }

            lastValue = position;
        }

        /// <summary>
        /// Bewegungsrichtung auf den forward-Vektor des Orientierungsobjekts setzen.
        /// </summary>
        protected override void UpdateDirection()
        {
            Direction = orientationObject.transform.forward;
            Direction.y = 0.0f;
            Direction.Normalize();
        }
        
        /// <summary>
        /// Update der Orientierung des GameObjects,
        /// das die Bewegungsrichtung definiert..
        /// </summary>
        /// <remarks>
        /// Für die Verarbeitung der Orientierung verwenden wir
        /// die Eulerwinkel der x- und y-Achse.
        ///
        /// Wird aktuell nicht verwendet, da wir die Bewegungsrichtung
        /// direkt aus dem forward-Vektor des Orientierungsobjekts
        /// ablesen.
        /// </remarks>
        protected override void UpdateOrientation()
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// Speicher für den vorletzten Wert
        /// </summary>
        private float lastValue = 1.6f;
    }
}
