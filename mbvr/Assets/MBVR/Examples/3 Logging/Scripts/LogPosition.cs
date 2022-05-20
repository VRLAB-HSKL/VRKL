using log4net;
using UnityEngine;
using HTC.UnityPlugin.Vive;

/// <summary>
/// Logging für die Position eines getrackten Objekts.
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
        string info = "";
        string seperator = ";";
        // Wir können mit dem Aufzählungstyp DeviceRole
        // alles abfragen zu dem es getrackte Daten gibt.
        // Hmd, der Default, ist klar.
        // Die beiden Controller erhalten wir mit Device1 (rechts)
        // und Device 2 (links).
        Vector3 trackerTrace = VivePose.GetPoseEx(trackedObject).pos;
        info = trackerTrace.x.ToString() + seperator + 
                   trackerTrace.y.ToString() + seperator +
                   trackerTrace.z.ToString() + seperator +
                   trackedObject.ToString();
        Log.Info(info);
    }
    
    /// <summary>
    /// Instanz eines Loggers
    /// </summary>
    private static readonly ILog Log = 
        LogManager.GetLogger(typeof(LogPosition));
}
