using log4net;
using UnityEngine;
using HTC.UnityPlugin.Vive;

/// <summary>
/// Logging f�r die Position eines getrackten Objekts.
/// </summary>
/// <remarks>
///Wir verwenden das Logging-Level INFO in Log4Net!
/// </remarks>
public class LogPosition : MonoBehaviour
{
    [Tooltip("Hmd, Device1=RightHand, Device2=LeftHand")]
    public DeviceRole trackedObject = DeviceRole.Hmd;

    private void Update()
    {
        var info = "";
        var separator = ";";
        // Wir k�nnen mit dem Aufz�hlungstyp DeviceRole
        // alles abfragen zu dem es getrackte Daten gibt.
        // Hmd, der Default, ist klar.
        // Die beiden Controller erhalten wir mit Device1 (rechts)
        // und Device 2 (links).
        var trackerTrace = VivePose.GetPoseEx(trackedObject).pos;
        info = trackerTrace.x.ToString() + separator + 
                   trackerTrace.y.ToString() + separator +
                   trackerTrace.z.ToString() + separator +
                   trackedObject.ToString();
        Log.Info(info);
    }
    
    /// <summary>
    /// Instanz eines Loggers
    /// </summary>
    private static readonly ILog Log = 
        LogManager.GetLogger(typeof(LogPosition));
}
