using System;
using HTC.UnityPlugin.Vive;
using UnityEngine;

namespace VRKL.MBVR
{
    /// <summary>
    /// Walking in Place mit einem getrackten Objekt.
    /// </summary>
    /// <remarks>
    /// Typischer Weise wird Walking in Place mit zwei F�ssen
    /// oder zwei Armen gezeigt.
    ///
    /// Diese Klasse beobachtet ein getracktes Objekt und die
    /// die Ver�nderungen der y-Koordinate. Ist die Differenz zwischen
    /// aktuellen y-Wert und dem im letzten Frame gr��er als ein Schwellwert
    /// wird der Trigger f�r die Bewegung durchgef�hrt.
    ///
    /// Welches Objekt wir beobachten kann im Inspektor eingestellt werden.
    /// Wir verwenden hier einfach das bereits deklarierte Objekt moveHand.
    /// </remarks>
    public class WalkingInPlaceOneLimb : Walk
    {
        [Tooltip("Schwellwert f�r das Ausl�sen der Bewegung")]
        [Range(0.01f, 1.0f)]
        public float Threshold = 0.05f;
        
        /// <summary>
        /// Walk wird so lange durchgef�hrt bis der Trigger-Button
        /// wieder gedr�ckt wird.
        /// </summary>
        protected override void Trigger()
        {
            float velocity, 
                    position = orientationObject.transform.position.y;
           
            /*Debug.Log("OldPosition");
            Debug.Log(lastValue);
            Debug.Log("Position");
            Debug.Log(position);*/
            
            // Velocity: numerisches Differenzieren
            velocity = (position - lastValue) / Time.deltaTime;
            Debug.Log("Geschwindigkeit");
            Debug.Log(velocity);
            if ( Mathf.Abs(velocity) > Threshold )
            {
                Moving = true;
                Debug.Log("Move!");
            }
            else
            {
                Moving = false;
            }

            lastValue = position;
        }
        
        private float lastValue = 1.6f;
    }
}