/// <summary>
/// Abstrakte Basisklasse für eine State Machine.
/// Diese Klasse kann bei Bedarf erweitert werden.
/// 
/// Von dieser Basisklasse abgeleitete Klassen
/// implementieren häufig das Singleton Pattern!
/// </summary>
public abstract class State
{
    protected State() { }

    /// <summary>
    /// Wird während des Eintretens in einen State aufgerufen
    /// </summary>
    public abstract void OnStateEntered();

    /// <summary>
    /// Wird aufgerufen während der State aktiv ist
    /// </summary>
    public abstract void OnStateUpdate();

    /// <summary>
    /// Wird während des Verlassens eines States aufgerufen
    /// </summary>
    public abstract void OnStateQuit();

    /// <summary>
    /// Jeder Zustand weiß, was der nachfolgende Zustand ist
    /// und wechselt in diesen Zustand mit Hilfe dieser Funktion.
    /// </summary>
    public abstract State ChangeState();
}
