//========= 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;

/// <summary>
/// Namespace für Unity-Assets in VR-Anwendungen
/// </summary>
namespace VRKL.MBVR
{
    /// <summary>
    /// Den VIU-Simulator auf dem Desktop mit einem Button beenden.
    /// <remarks>
    /// Wir verwenden die Klasse Input und die Buttons, die
    /// im Input-Manager definiert sind. Diese Belegungen erhalten 
    /// wir mit Edit -> Project Settings -> input Manager.
    /// 
    /// Dort werden logische Namen wie Submit, Cancel oder Fire<x>
    /// und die Belegung dafür definiert. Der Vorteil dieser Methode
    /// ist, dass wir nicht nur physikalisch vorhandene Tasten, sondern
    /// auch Joystick-Buttons verwenden können falls sie vorhanden sind.
    /// 
    /// Default ist "Fire2", was im Normalfall auf der Tastatur
    /// der linken Alt-Taste entspricht. Wir müssen etwas anderes als
    /// den ESC-Button verwenden, da dieser im VIU-Simulator bereits
    /// für das Pausieren der Anwendung eingesetzt wird.
    ///
    /// "Fire3" scheidet inzwischen aus, da wir die Shift-Taste im Simulator
    /// für das Touchpad benötigen!
    /// </remarks>
    /// </summary>
    public class QuitVIUSimulator : MonoBehaviour
    {
        /// <summary>
        /// Die Taste mit dem Input-Manager abfragen.
        /// </summary>
        private void Update()
        {
            if (VIUSettings.activateSimulatorModule && Input.GetButton(STOP_BUTTON))
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }

        /// <summary>
        /// Button für das Beenden des Simulators
        /// </summary>
        private const string STOP_BUTTON = "Fire2";
    }
}

/*! \mainpage
* Eine mit doxygen erstellte HTML-Dokumentation des Unity-Packages MBVR.
*
* Beispiele für die Verwendung der Klassen und Assets finden Sie im Verzeichnis
* Examples.
 */
