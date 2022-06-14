using UnityEngine;
using log4net;

/// <summary>
/// Ein Objekt, dem diese Klasse hinzugefügt wird 
/// verfolgt ein Zielobjekt mit Hilfe von einfacher Physik.der Funktion
/// 
/// 
/// Ein GameObject, das diese Klasse verwenden soll
/// muss eine Rigidbody Component besitzen.
/// Dies wird nmit Hilfe von RequireComponent sichergestellt.
/// </summary>
/// 
[RequireComponent(typeof(Rigidbody))]
public class FollowerWithLogs : MonoBehaviour
{
    /// <summary>
    /// Position und Orientierung des verfolgten Objekts
    /// </summary>
    [Tooltip("Das verfolgte Objekt")]
    public Transform playerTransform;
    /// <summary>
    /// Geschwindigkeit des Objekts
    /// </summary>
    [Tooltip("Geschwindigkeit")]
    public float speed = 10.0F;
    /// <summary>
    /// Soll der Strahl zwischen Ziel und dem aktuellen Objekt angezeigt werden?
    /// </summary>
    [Tooltip("Anzeige des Vektors, der für die Verfolgung berechnet wird im Play.Modus")] 
	public bool showRay = false;

    /// <summary>
    /// Instanz eines Loggers
    /// </summary>
    /// <remarks>
    ///Wir verwenden den Namespace für ILog und LogManager,
    /// um Verwechslungen zu vermeiden.
    /// </remarks>
    private static readonly log4net.ILog Log = 
        log4net.LogManager.GetLogger(typeof(FollowerWithLogs));

    
    /// <summary>
    /// Start-Funktion mit Protokollausgaben
    /// </summary>
    private void Start()
    {
        Log.Debug(">> " + gameObject.name + ".Start");
        Log.Info("Info-Ausgabe in Start");
        Log.Debug("<< " + gameObject.name + ".Start");
    }

    /// <summary>
    /// Bewegung in FixedUpdate (Time.deltaTime!)
    /// 
    /// Erster Schritt: Keyboard abfragen und bewegen.
    /// Zweiter Schritt: überprüfen, ob wir im zulässigen Bereich sind.
    /// </summary>
    private void FixedUpdate ()
    {
        Log.Debug(">>>" + gameObject.name + ".FixedUpdate");
        // Schrittweite
        float stepSize = speed * Time.deltaTime;

        var source = transform.position;
		var target = playerTransform.position;

        // Neue Position berechnen
		transform.position = Vector3.MoveTowards(source, target, stepSize);
        transform.LookAt(playerTransform);
        if (showRay)
			Debug.DrawRay(transform.position, 100.0f * transform.forward, Color.red);
        Log.Info("Neue Position des Objekts: " + transform.position.ToString());
        Log.Debug("<<" + gameObject.name + ".FixedUpdate");
    }
}
