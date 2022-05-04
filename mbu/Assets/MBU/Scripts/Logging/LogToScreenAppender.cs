using UnityEngine;
using log4net.Appender;
using log4net.Core;
using UnityEngine.UI;

/// <summary>
/// Log4Net-Appender, der die Logs in die Text-Komponente eines
/// in der Szene befindlichen GameObjects schreibt.
/// </summary>
/// <remarks>
///Wir geben maximal fünf Zeilen aus. Trifft eine neue Zeile ein rollen
/// die Inhalte weiter. Die neue Nachricht wird in der fünften Zeile ausgeben,
/// die bisher angezeigten Texte rollen nach oben, der Text in der ersten Zeile
/// wird gelöscht.
/// </remarks>
public class LogToScreenAppender : AppenderSkeleton
{
    /// <summary>
    /// Implementierung der Ausgabe
    /// </summary>
    /// <remarks>
    ///Wir unterscheiden nicht nach verschiedenen Levels.
    /// </remarks>
    /// <param name="loggingEvent"
    /// Logging-Event mit den Inhalten,
    /// die wir ausgeben.
    //</param>
    protected override void Append(LoggingEvent loggingEvent)
    {
        var message = RenderLoggingEvent(loggingEvent);
        WriteToScreen(message);
    }

    /// <summary>
    /// Ausgabe des Texts auf die Text-Komponente
    /// </summary>
    /// <remarks>
    /// In dieser Funktion wird die Verbindung zur Text-Component
    /// hergestellt!
    /// </remarks>
    /// <param name="message">Text aus dem Logger</param>
    void WriteToScreen(string message) 
    {
        logText = GameObject.Find("LoggerOutput").GetComponent<Text>();
        msg1 = msg2;
        msg2 = msg3;
        msg3 = msg4;
        msg4 = msg5;
        msg5 = message;
        logText.text  = msg1 +"\n" + msg1 + "\n" + msg2 + "\n" + msg3 + "\n" + msg4 + "\n";
    }
    
    /// <summary>
    /// Text-Component eines GameObjects in der Szene.
    /// </summary>
    private Text logText;
    /// <summary>
    /// Erste ausgegebene Zeile.
    /// </summary>
    private string msg1 = "";
    /// <summary>
    /// Zweite ausgegebene Zeile.
    /// </summary>
    private string msg2 = "";
    /// <summary>
    /// Dritte ausgegebene Zeile.
    /// </summary>
    private string msg3 = "";
    /// <summary>
    /// Vierte ausgegebene Zeile.
    /// </summary>
    private string msg4 = "";
    /// <summary>
    /// Fünfte ausgegebene Zeile.
    /// </summary>
    private string msg5 = "";
}