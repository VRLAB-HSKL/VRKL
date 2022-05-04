using log4net.Appender;
using log4net.Core;
using UnityEngine;

/// <summary> 
/// Log4Net-Appender für die Unity Console.
/// </summary>
/// <remarks>
///  Alle Logging-Level werden mit Debug.Log ausgegeben,
/// ohne Veränderung.
///
/// Granularer kann man dies mit der Klasse
/// <code>UnityConsoleAppender</code>
/// durchführen.
/// </remarks>
public class UnityDebugAppender : AppenderSkeleton
{
    /// <summary>
    /// Überschreiben der Funktion Append
    /// </summary>
    /// <param name="loggingEvent">
    /// Logging-Event mit den Inhalten,
    /// die wir ausgeben.
    /// </param>
  protected override void Append(LoggingEvent loggingEvent)
  {
    var message = RenderLoggingEvent(loggingEvent);
    Debug.Log(message);
  }
}
