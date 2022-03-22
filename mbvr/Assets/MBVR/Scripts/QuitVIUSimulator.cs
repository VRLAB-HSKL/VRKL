//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;

/// <summary>
    /// Den VIU-Simulator mit dem Cancel-Button beenden.
    /// <remarks>
    /// Wir verwenden die Klasse Input und die Buttons, die
    /// im Input-Manager definiert sind. Diese Belegungen erhalten 
    /// wir mit Edit -> Project Settings -> input Manager.
    /// 
    /// Dort werden logische Namen wie Submit, Cancel oder Jump
    /// und die Buttons dafür definiert. Der Vorteil dieser Methode
    /// ist, dass wir nicht nur physikalisch vorhandene Tasten, sondern
    /// auch Joystick-Buttons verwenden können wenn sie vorhanden sind.
    /// 
    /// Default ist "Fire3", was im Normalfall auf der Tastatur
	/// der linken Shift-Taste entspricht. Wir müssen etwas anderes als
	/// den ESC-Button verwenden, da dieser im Simulator bereits
	/// für das Pausieren der Anwendung eingesetzt wird.
    /// </remarks>
    /// </summary>
    public class QuitVIUSimulator : MonoBehaviour
    {
        /// <summary>
        /// Die Taste mit dem Input-Manager abfragen.
        /// </summary>
        private void Update()
        {
            if (VIUSettings.activateSimulatorModule)
            {
                

                if (Input.GetButton("Fire3"))
                {
                    Debug.Log("Simulator wird beendet!");
                    Application.Quit();
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
                }
            }
        }
    }
