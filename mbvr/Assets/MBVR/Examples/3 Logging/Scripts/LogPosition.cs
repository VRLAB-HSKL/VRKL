using log4net;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class LogPosition : MonoBehaviour
{
    [Tooltip("Hmd, Device1=RightHand, Device2=LeftHand")]
    public DeviceRole trackedObject = DeviceRole.Hmd;

    private void Update()
    {
        // Wir können mit dem Aufzählungstyp DeviceRole
        // alles abfragen zu dem es getrackte Daten gibt.
        // Hmd, der Default, ist klar.
        // Die beiden Controller erhalten wir mit Device1 (rechts)
        // und Device 2 (links).
        Vector3 trackerTrace = VivePose.GetPoseEx(trackedObject).pos;
        Debug.Log(trackerTrace);
        Debug.Log("---");
    }
    
    /// <summary>
    /// Instanz eines Loggers
    /// </summary>
    private static readonly ILog Log = 
        LogManager.GetLogger(typeof(LogPosition));
}
