//========= 2021 - 2022 - Copyright Manfred Brill. All rights reserved. ===========

namespace VRKL.MBVR
{
    /// <summary>
    /// Fly als Locomotion in einer VR-Anwendung, mit zwei Objekten für
    /// die Definition der Bewegungsrichtung.
    /// </summary>
    /// <remarks>
    /// Fly bedeutet, dass wir die Bewegungsrichtung in allen drei
    /// Koordinatenachsen verändern können.
    ///
    /// Wir verwenden einen Trigger-Button. So lange dieser Button
    /// gedrückt ist wird die Bewegung ausgeführt.
    /// 
    /// Als Bewegungsrichtung verwenden wir den Differenzvektor
    /// zweier Objekte, typischer Weise die Controller. Möglich ist
    /// auch den Kopf als einer der Objekte zu verwenden.
    ///
    /// Die Geschwindigkeit wird mit Buttons auf einem Controller
    /// verändert.
    /// </remarks>
    public class DifferenceFly : TwoObjectsDirection
    {
        /// <summary>
        /// Bewegungsrichtung als Differenz der forward-Vektoren
        /// der beiden definierenden Objekte setzen.
        /// </summary>
        /// <remarks>
        /// Implementierung stimmt aktuell mit InitializeDirection überein.
        /// </remarks>
        protected override void UpdateDirection()
        {
            Direction = endObject.transform.position - startObject.transform.position;
            Direction.Normalize();
        }

        protected override void UpdateOrientation()
        {
            throw new System.NotImplementedException();
        }
    }
}
