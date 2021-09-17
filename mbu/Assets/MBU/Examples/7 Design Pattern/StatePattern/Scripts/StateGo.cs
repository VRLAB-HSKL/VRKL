/// <summary>
/// State für "Ampel ist grün"
/// </summary>
sealed class StateGo : TrafficState
{
    /// <summary>
    /// Instanz-Variable für das Abfragen. 
    /// <remarks>
    /// Wir verwenden die Instanz mit
    /// <code>StateGo s = StateGo.Instance;</code>.
    /// </remarks>
    /// </summary>
    public static readonly StateGo Instance = new StateGo();

    /// <summary>
    /// Private Konstruktor für das Singleton-Pattern.
    /// <remarks>
    /// Quelle für die Implementierung des Patterns:
    /// https://wiki.byte-welt.net/wiki/Singleton_Beispiele_(Design_Pattern)#Eager_Creation
    /// </remarks>
    /// </summary>
    private StateGo()
    {
        _state = TrafficLightStates.Go;
    }

    /// <summary>
    /// Wird während des Eintretens in einen State aufgerufen
    /// </summary>
    public override void OnStateEntered()
    {
    }

    /// <summary>
    /// Wird aufgerufen während der State aktiv ist
    /// </summary>
    public override void OnStateUpdate()
    {
    }

    /// <summary>
    /// Wird während des Verlassens eines States aufgerufen
    /// </summary>
    public override void OnStateQuit()
    {
    }

    /// <summary>
    /// Wir wechseln von "Grün" auf "Gelb"
    /// </summary>
    public override TrafficState ChangeState()
    {
        OnStateQuit();
        StateAttention.Instance.OnStateEntered();
        return StateAttention.Instance;
    }
}
