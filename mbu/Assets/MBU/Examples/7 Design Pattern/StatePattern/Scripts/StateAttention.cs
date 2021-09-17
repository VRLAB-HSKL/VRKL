/// <summary>
/// State für "Ampel wird demnächst rot"
/// </summary>
sealed class StateAttention : TrafficState
{
    /// <summary>
    /// Instanz-Variable für das Abfragen. 
    /// <remarks>
    /// Wir verwenden die Instanz mit
    /// <code>StateAttention s = StateAttention.Instance;</code>.
    /// </remarks>
    /// </summary>
    public static readonly StateAttention Instance = new StateAttention();

    /// <summary>
    /// Private Konstruktor für das Singleton-Pattern.
    /// <remarks>
    /// Quelle für die Implementierung des Patterns:
    /// https://wiki.byte-welt.net/wiki/Singleton_Beispiele_(Design_Pattern)#Eager_Creation
    /// </remarks>
    /// </summary>
    private StateAttention()
    {
        _state = TrafficLightStates.Attention;
    }

    /// <summary>
    /// Wird während des Eintretens in einen State aufgerufen
    /// </summary>
    public override void OnStateEntered()
    {}

    /// <summary>
    /// Wird aufgerufen während der State aktiv ist
    /// </summary>
    public override void OnStateUpdate()
    {}

    /// <summary>
    /// Wird während des Verlassens eines States aufgerufen
    /// </summary>
    public override void OnStateQuit()
    {}

    /// <summary>
    /// Wir wechseln von "Gelb" auf "Rot"
    /// </summary>
    public override TrafficState ChangeState()
    {
        OnStateQuit();
        StateStop.Instance.OnStateEntered();
        return StateStop.Instance;
    }
}
