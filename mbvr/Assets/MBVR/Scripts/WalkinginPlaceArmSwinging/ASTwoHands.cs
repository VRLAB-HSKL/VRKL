using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Arm-Swinging mit beiden Armen, um eine Locomotion auszulösen.
    /// </summary>
    /// <remarks>
    /// Wir beobachten die y-Koordinaten beider Arme  und entscheiden damit,
    /// ob wir uns fortbewegen möchten. Keine weiteren Strategien.
    /// </remarks>
    public class ASTwoHands : InPlaceLocomotion
    {
        [Header("GameObjects für die Bewegung der Arme")]
        /// <summary>
        /// GameObject, mit dem wir die Bewegung des rechten Arms überwachen
        /// </summary>
        [Tooltip("Rechter Arm")]
        public GameObject triggerRight;
        /// <summary>
        /// GameObject, mit dem wir die Bewegung des linken Arms überwachen
        /// </summary>
        [Tooltip("Linker Arm")]
        public GameObject triggerLeft;
        
        [Header("Schwellwert für das Triggern der Locomotion")]     
        [Tooltip("Schwellwert für das Auslösen der Bewegung")] [Range(0.01f, 1.0f)]
        public float Threshold = 0.05f;

        /// <summary>
        /// Walk wird so lange durchgeführt wie das Trigger-Objekt  bewegt wird.
        /// Das entscheiden wir auf Grund der Geschwindigkeit dieser
        /// Veränderung, die wir
        /// mit Hilfe von numerischem Differenzieren schätzen.
        /// </summary>
        protected override void Trigger()
        {
            float positionRight = 0.0f,
                   positionLeft = 0.0f,
                  signalVelocityRight = 0.0f,
                   signalVelocityLeft = 0.0f ;

            // Numerisches Differenzieren
            positionRight = triggerRight.transform.position.y;
            positionLeft = triggerLeft.transform.position.y;
            signalVelocityRight = (positionRight - lastValueRight) / Time.deltaTime;
            signalVelocityLeft = (positionLeft - lastValueLeft) / Time.deltaTime;
            Moving = (Mathf.Abs(signalVelocityRight) > Threshold) || (Mathf.Abs(signalVelocityLeft) > Threshold) ;

            lastValueRight = positionRight;
            lastValueLeft = positionLeft;
        }

        /// <summary>
        /// Speicher für den letzten Wert
        /// </summary>
        private float lastValueRight = 1.6f,
                          lastValueLeft = 1.6f;
    }
}