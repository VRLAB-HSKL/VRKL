//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace f�r allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Abstrakte Basisklasse f�r die Bewegung eines GameObjects entlang einer Kurve
    /// </summary>
    public abstract class PathAnimation : MonoBehaviour
    {
        /// <summary>
		///Wir n�hern die Kurve mit Hilfe von Waypoints an.
		/// </summary)
		[Range(8, 1024)]
        [Tooltip("Anzahl der Waypoints")]
        public int NumberOfPoints = 64;
        /// <summary>
        /// Ist das Objekt n�her beim aktuellen Waypoint als distance,
        /// wird der n�chste Waypoint verwendet.
        /// </summary>
        [Range(0.1f, 10.0f)]
        [Tooltip("Minimaler Abstand zu einem Waypoint")]
        public float distance = 1.0f;
        /// <summary>
        /// Geschwindigkeit der Bewegung
        /// </summary>
        [Range(0.1f, 100.0f)]
        [Tooltip("Geschwindigkeit der Bewegung")]
        public float speed = 5.0f;

        /// <summary>
        /// Instanz der Klasse WaypointManager
        /// 
        /// Die Berechnung von Positionen und die Verwaltung
        /// der Zielpunkte erfolgt in dieser C#-Klasse.
        /// Sie ist *nicht* von MonoBehaviour abgeleitet!
        /// </summary>
        protected WaypointManager manager = null;
        /// <summary>
        /// Array mit Instanzen von Vector3 f�r die Waypoints
        /// </summary>
        protected Vector3[] waypoints;

        /// <summary>
        /// Die Zielpunkte berechnen und damit eine neue Instanz von WaypointManager erzeugen.
        /// Es wird direkt das erste Ziel abgefragt, da wir diese Variable
        /// in FixedUpdate an die Instanz des WaypointManagers �bergeben, um die
        /// Position zu ver�ndern.
        /// </summary>
        protected virtual void Awake()
        {
            ComputePath();

            this.manager = new WaypointManager(this.waypoints, distance);
            // Den ersten Zielpunkt setzen
            transform.position = manager.GetWaypoint();
            // Orientierung setzen
            // Wichtig: wir k�nnten hier auch einen up-Vektor �bergeben.
            // Der Defaultwert daf�r ist der up-Vektor des WKS, also die y-Achse.
            transform.LookAt(ComputeFirstLookAt());
        }


        /// <summary>
        /// Wir verwenden FixedUpdate, da wir mit Time.deltaTime arbeiten.
        /// </summary>
        protected virtual void FixedUpdate()
        {
            // Objekt mit Hilfe von MoveTowards bewegen
            transform.position = this.manager.Move(
                transform.position,
                speed * Time.deltaTime);
            transform.LookAt(manager.GetFollowupWaypoint());
        }

        /// <summary>
        /// Abstrakte Funktion ComputePath. Muss von den abgeleiteten Klassen
        /// implementiert werden und enth�lt die Parameterdarstellung der
        /// Kurve.
        /// </summary>
        protected abstract void ComputePath();

        /// <summary>
        /// Berechnung der ersten Lookat-Punkts. 
        /// Damit k�nnen wir das gesteuerte Objekt ausrichten.
        /// 
        /// Als Default wird hier forward verwendet. Abgeleitete Klassen
        /// k�nnen f�r den ersten Punkt die Tangente berechnen und hier setzen.
        /// </summary>
        /// <returns>Punkt, der LookAt �bergeben werden kann</returns>
        protected virtual Vector3 ComputeFirstLookAt()
        {
            return new Vector3(0.0f, 0.0f, 1.0f);
        }
    }
}
