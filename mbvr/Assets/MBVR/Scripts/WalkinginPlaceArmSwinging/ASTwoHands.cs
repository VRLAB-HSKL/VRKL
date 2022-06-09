using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Arm-Swinging mit beiden Armen, um eine Locomotion auszul�sen.
    /// </summary>
    /// <remarks>
    /// Wir beobachten die y-Koordinaten beider Arme  und entscheiden damit,
    /// ob wir uns fortbewegen m�chten. Keine weiteren Strategien.
    /// </remarks>
    public class ASTwoHands : InPlaceLocomotion
    {
        [Header("GameObjects für die Bewegung der Arme")]
        /// <summary>
        /// GameObject, mit dem wir die Bewegung des rechten Arms �berwachen
        /// </summary>
        [Tooltip("Rechter Arm")]
        public GameObject triggerRight;
        /// <summary>
        /// GameObject, mit dem wir die Bewegung des linken Arms �berwachen
        /// </summary>
        [Tooltip("Linker Arm")]
        public GameObject triggerLeft;
        
        [Header("Schwellwert f�r das Triggern der Locomotion")]     
        [Tooltip("Schwellwert f�r das Ausl�sen der Bewegung")] [Range(0.01f, 1.0f)]
        public float Threshold = 0.05f;

        /// <summary>
        /// Walk wird so lange durchgef�hrt wie das Trigger-Objekt  bewegt wird.
        /// Das entscheiden wir auf Grund der Geschwindigkeit dieser
        /// Ver�nderung, die wir
        /// mit Hilfe von numerischem Differenzieren sch�tzen.
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
        /// Speicher f�r den letzten Wert
        /// </summary>
        private float lastValueRight = 1.6f,
                          lastValueLeft = 1.6f;
    }
}