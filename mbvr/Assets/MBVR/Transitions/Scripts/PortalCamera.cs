using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    Portal[] portals;

    void Awake () {
        portals = FindObjectsOfType<Portal> ();
    }

    void OnPreCull () {

        // for (int i = 0; i < portals.Length; i++) {
        //     portals[i].PrePortalRender ();
        // }
        
        for (var i = 0; i < portals.Length; i++) {
            portals[i].Render ();
        }

        // for (int i = 0; i < portals.Length; i++) {
        //     portals[i].PostPortalRender ();
        // }

    }
}
