//========= 2021 2022 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using Unity;

namespace VRKL.MBVR
{
    /// <summary>
    /// Fly als Locomotion in einer VR-Anwendung. 
    /// </summary>
    /// <remarks>
    /// Fly bedeutet, dass wir die Bewegungsrichtung in allen drei
    /// Koordinatenachsen verändern können.
    ///
    /// Wir verwenden einen Trigger-Button. So lange dieser Button
    /// gedrückt ist wird die Bewegung ausgeführt.
    /// 
    /// Als Bewegungsrichtung verwenden wir die Orientierung
    /// eines GameObjects, typischer Weise eines der Controllert.
    ///
    /// Die Geschwindigkeit wird mit Buttons auf einem Controller
    /// verändert.
    /// </remarks>
    /// \todo Statt Trigger zu halten könnten wir auch den State ändern zwischen
    /// bewegen und nicht bewegen, mit Hilfe von 2x auslösen des Triggers,
    /// wie das in der VIU auch bei grab angeboten wird.
    public class Fly : SingleOrientation
    {
        /// <summary>
        /// Update der Orientierung des GameObjects,
        /// das die Bewegungsrichtung definiert..
        /// </summary>
        /// <remarks>
        /// Für die Verarbeitung der Orientierung verwenden wir
        /// die Eulerwinke der x- und y-Achse.
        /// </remarks>
        /// \todo Prüfen, ob wir in x nicht den negativen Eulerwinkel übertragen müssen.
        protected override void UpdateOrientation()
        {
            Orientation.x = orientationObject.transform.eulerAngles.x;
            Orientation.y = orientationObject.transform.eulerAngles.y;
        }
    }
}
