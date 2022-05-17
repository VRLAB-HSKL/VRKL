using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Abstrakte Basisklasse für Locomotion-Verfahren,
    /// bei denen etwas "auf der Stelle" durchgeführt wird
    /// wie Walking-in-Place oder Arm-Swinging.
    /// </summary>
    /// <remarks>
    /// Diese Klasse ist von VRKL.MBU.Locomotion abgeleitet.
    ///
    /// Welche getrackten Objekte wir verwenden und wie viele
    /// legen wir in den von dieser Klasse abgeleiteten Klassen fest!
    /// </remarks>
    public abstract class InPlaceLocomotion : VRKL.MBU.Locomotion
    {
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
        
        /// <summary>
        /// Geschwindigkeit für die Bewegung der Kamera in km/.
        /// </summary>
        /// <remarks>
        /// Vorerst protected gesetzt. Mittelfristig werden wir
        /// die Geschwindigkeit aus der Bewegung auf der Stelle
        /// herauslesen.
        /// </remarks>
        private float initialSpeed = 5.0f; 
        
        /// <summary>
        /// Maximale Geschwindigkeit für die Bewegung der Kamera in km/.
        /// </summary>
        /// <remarks>
        /// Vorerst protected gesetzt. Mittelfristig werden wir
        /// die Geschwindigkeit aus der Bewegung auf der Stelle
        /// herauslesen.
        /// </remarks>
        private float vMax = 10.0f;

        /// <summary>
        /// Delta für das Verändern der Geschwindigkeit
        /// </summary>

        private float vDelta = 0.2f;

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
            // Vorerst machen wir kein Update auf die Bahngeschwindigkeit
            // Diese ist aktuell konstant!
            //UpdateSpeed();
            Trigger();
            Move();
        }

        /// <summary>
        /// Die Bewegung durchführen.
        /// </summary>
        /// <remarks>
        /// Die Bewegung wird durchgeführt, wenn eine in dieser Klasse
        /// deklarierte logische Variable true ist.
        /// <remarks>
        protected override void Move()
        {
            if (Moving)
                transform.Translate(Speed * Time.deltaTime * Direction);
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
            Speed = initialSpeed/3.6f;
            Debug.Log("Speed initialisiert");
            Debug.Log(Speed);
        }

        /// <summary>
        /// Die abgeleiteten Klassen entscheiden, wann die Locomotion
        /// getriggert werden.
        /// </summary>
        protected abstract void Trigger();

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
        /// Bewegungsrichtung auf den forward-Vektor des Orientierungsobjekts setzen.
        /// </summary>
        /// <remarks>
        /// Vorerst protected gesetzt. Mittelfristig werden wir
        /// die Geschwindigkeit aus der Bewegung auf der Stelle
        /// herauslesen.
        /// </remarks>
        protected override void InitializeDirection()
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
    }
}
