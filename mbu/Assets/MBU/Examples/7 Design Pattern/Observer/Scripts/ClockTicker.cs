using UnityEngine;

public class ClockTicker : MonoBehaviour
{
    /// <summary>
    /// Das beobachtete Objekt
    /// </summary>
    private Clock _clock;
    
     /// <summary>
     /// Die Instance der Uhr erzeugen
     /// </summary>
    private void Awake()
    {
        _clock = Clock.Instance;
    }

    /// <summary>
    /// Wir lassen die Uhr zentral ticken
    /// </summary>
    private  void FixedUpdate()
    {
        _clock.Tick();
    }
}
