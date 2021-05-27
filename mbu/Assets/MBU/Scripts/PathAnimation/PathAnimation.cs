//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace für allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Abstrakte Basisklasse für die Bewegung eines GameObjects entlang einer Kurve
    /// </summary>
    public abstract class PathAnimation : MonoBehaviour
    {
        /// <summary>
		///Wir nähern die Kurve mit Hilfe von Waypoints an.
		/// </summary)
		[Range(8, 1024)]
        [Tooltip("Anzahl der Waypoints")]
        public int NumberOfPoints = 64;
        /// <summary>
        /// Ist das Objekt näher beim aktuellen Waypoint als distance,
        /// wird der nächste Waypoint verwendet.
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
        /// Array mit Instanzen von Vector3 für die Waypoints
        /// </summary>
        protected Vector3[] waypoints;

        /// <summary>
        /// Komponente WayPointManager abfragen und speichern.
        /// Wir fragen auch das erste Ziel ab.
        /// </summary>
        protected virtual void Awake()
        {
            ComputePath();
            this.manager = new WaypointManager(this.waypoints, distance);
            // Den ersten Zielpunkt setzen
            transform.position = manager.GetWaypoint();
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
        }

        // Erster Versuch mit einem Kreis
        protected abstract void ComputePath();
    }
}
