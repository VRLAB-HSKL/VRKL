using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Walking-in-Place mit einem Beind, um eine Locomotion auszulösen.
    /// </summary>
    /// <remarks>
    /// Wir beobachten die y-Koordinaten eines Trackers, der an einem
    /// Bein angebracht wird und entscheiden damit,
    /// ob wir uns fortbewegen möchten. Keine weiteren Strategien.
    /// </remarks>
    public class WIPOneLeg : InPlaceLocomotion
    {
        [Header("Trigger Device")]
        /// <summary>
        /// Welchen Tracker verwenden wir für das Triggern der Fortbewegung?
        /// </summary>
        [Tooltip("Welcher Tracker bewegt sich?")]
        public GameObject triggerObject;

        [Tooltip("Schwellwert für das Auslösen der Bewegung")]
        [Range(0.01f, 1.0f)]
        public float Threshold = 0.05f;
        
        /// <summary>
        /// Walk wird so lange durchgeführt wie das Trigger-Objekt  bewegt wird.
        /// Das entscheiden wir auf Grund der Geschwindigkeit dieser
        /// Veränderung, die wir
        /// mit Hilfe von numerischem Differenzieren schätzen.
        /// </summary>
        protected override void Trigger()
        {
            float position = 0.0f,
                signalVelocity = 0.0f;
            
            // Numerisches Differenzieren
            position = triggerObject.transform.position.y;
            signalVelocity = (position - lastValue) / Time.deltaTime;
            Moving = Mathf.Abs(signalVelocity) > Threshold;

            lastValue = position;
        }
        /// <summary>
        /// Speicher für den letzten Wert
        /// </summary>
        private float lastValue = 1.6f;
    }
}
