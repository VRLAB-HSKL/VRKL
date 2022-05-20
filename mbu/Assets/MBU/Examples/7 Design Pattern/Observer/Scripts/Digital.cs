using TMPro;
using VRKL.MBU;

/// <summary>
/// Eine Anzeige einer Digitaluhr mit der Ausgabe von Sekunden
/// </summary>
public class Digital : Observer
{
    /// <summary>
    /// Das beobachtete Objekt
    /// </summary>
    private Clock Model;

    /// <summary>
    /// Text-Feld f�r die Ausgabe der Digitaluhr
    /// </summary>
    public TextMeshPro m_txt;

    /// <summary>
    /// In Awake stellen die Verbindung zur Subject-Klasse her.
    /// </summary>

    private void Awake()
    {
        Model = Clock.Instance;
        Model.Attach(this);
    }

    /// <summary>
    /// wir bauen den Text den wir ausgeben zusammen.
    /// </summary>
    /// <returns></returns>
    public override void Refresh()
    {
        var timeOutput = Model.Hour + " : " + Model.Minute + " : " + Model.Second;
        m_txt.text = timeOutput;
    }
}
