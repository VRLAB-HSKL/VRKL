using System;
using VRKL.MBU;

/// <summary>
/// Subject-Klasse für eine Uhr
/// </summary>
public class Clock : Subject
{
    /// <summary>
    /// Singleton-Pattern
    /// <remarks>
    /// Wir verwenden die Instanz mit
    /// <code>Clock c = Clock.Instance;</code>.
    /// </remarks>
    /// </summary>
    public static readonly Clock Instance = new Clock();
    
    private Clock() : base()
    {
        DateTime time = DateTime.Now;
        Hour = time.Hour;
        Minute = time.Minute;
        Second = time.Second;
    }

    /// <summary>
    /// Wie in Gamma lassen wir die Uhr ticken
    /// und benachrichtigen alle Observer.
    /// </summary>
    public void Tick()
    {
        DateTime time = DateTime.Now;
        Hour = time.Hour;
        Minute = time.Minute;
        Second = time.Second;

        Notify();
    }

    /// <summary>
    /// Variable für die Stunden
    /// </summary>
    public int Hour
    {
        get => _hour;
        set => _hour = value;
    }

    private int _hour { get; set; }
    /// <summary>
    /// Variable für die Minuten
    /// </summary>
    public int Minute
    {
        get => _minute;
        set => _minute = value;
    }
    private int _minute { get; set; }

    /// <summary>
    /// Variable für die Sekunden
    /// </summary>
    public int Second
    {
        get => _second;
        set => _second = value;
    }
    private int _second { get; set; }
}
