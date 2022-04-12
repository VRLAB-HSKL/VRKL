using System;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using VRKL.MBU;

namespace VRKL.MBVR
{
    public class VelocityVIU : Observer
    {
        [Header("Device")]
        /// <summary>
        /// Welchen Controller verwenden wir für die Veränderung der Geschwindigkeit?
        /// Als Default verwenden wir den Controller in der rechten Hand,
        /// also "RightHand" im "ViveCameraRig".
        /// </summary>
        [Tooltip("Rechter oder linker Controller für die Veränderung der Bahngeschwindigkeit?")]
        public HandRole gasHand = HandRole.RightHand;
        
        /// <summary>
        /// Button  für das Abbremsen der Fortbewegung.
        /// Default ist "Pad"
        /// </summary>
        [Tooltip("Button für das Abbremsen")] 
        public ControllerButton decButton = ControllerButton.Pad;

        /// <summary>
        /// Button  für das Beschleunigen der Fortbewegung.
        /// Default ist "Grip"
        /// </summary>
        [Tooltip("Button für das Beschleunigen")]
        public ControllerButton accButton = ControllerButton.Grip;
        
        [Header("Bahngeschwindigkeit")]
        /// <summary>
        /// Anfangswert für die Bahngeschwindigkeit
        /// </summary>
        [Tooltip(" Bahngeschwindigkeit")]
        [Range(0.0f, 100.0f)]
        public float Velocity = 0.2f;
        
        /// <summary>
        /// Delta für das Verändern der Geschwindigkeit
        /// </summary>
        [Tooltip("Delta für die Veränderung der Bahngeschwindigkeit")]
        [Range(0.001f, 1.0f)]
        public float vDelta = 0.2f;
        
        /// <summary>
        /// Maximal mögliche Geschwindigkeit
        /// </summary>
        [Tooltip("Maximal mögliche Bahngeschwindigkeit")]
        [Range(0.001f, 1.0f)]
        public static float vMax = 0.2f;
        
        /// <summary>
        /// Model anlegen
        /// </summary>
        void Awake()
        {
            Model = new ScalarProvider(Velocity, vDelta, 0.0f, vMax);
            Model.Attach(this);
            
            // Callbacks für Beschleunigung und Abbremsen
            ViveInput.AddListenerEx(moveHand, decButton, ButtonEventType.Down, Model.Decrease);
            ViveInput.AddListenerEx(moveHand, accButton, ButtonEventType.Down, Model.Increase);
        }
        
        public override void Refresh()
        {
            float value;
            value = Model.value;
        }

        /// <summary>
        /// Das beobachtete Objekt
        /// </summary>
        private ScalarProvider Model;
    }
}
