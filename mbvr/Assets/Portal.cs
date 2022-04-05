using System;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Assertions.Must;

/// <summary>
/// Based on youtube video: "Coding Adventure: Portal" by Sebastian Lague
/// github: SebLague
/// </summary>
public class Portal : MonoBehaviour
{
    public Portal otherPortal;
    public MeshRenderer screen;

    private Camera playerCam;
    private Camera portalCam;
    private RenderTexture viewTexture;

    private Vector3 initPlayerPos;
    private Quaternion initPlayerRot;

    private Vector3 initScreenPos;
    private Vector3 initPortalCamPos;
    private Vector3 initOtherPortalCamPos;
    
    private void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        //portalCam.enabled = false;

        initScreenPos = screen.transform.position;
        
        initPlayerPos = playerCam.transform.position;
        initPlayerRot = playerCam.transform.rotation;

        initPortalCamPos = portalCam.transform.position;

        var otherCam = otherPortal.GetComponent(typeof(Camera));
        initOtherPortalCamPos = otherCam.transform.position;
    }

    void CreateViewTexture()
    {
        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }

            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
                
            // Render the view from the portal camera to the view texture
            portalCam.targetTexture = viewTexture;
                
            // Display the view texture on the screen of the linked portal
            otherPortal.screen.material.SetTexture("_MainTex", viewTexture);
        }
    }

    // Called just before player camera is rendered
    public void OnPreRender()
    {
        screen.enabled = false;
        CreateViewTexture();
             
        //Make portal cam position and rotation the same relative to this portal as player cam relative to
        //other portal
        var m = transform.localToWorldMatrix *
                otherPortal.transform.worldToLocalMatrix *
                playerCam.transform.localToWorldMatrix;
              
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
        
        //     
        // //Render the camera
        // portalCam.Render();
        
        // Debug.Log(
        //     "playerMat[4x4]:\n" + transform.localToWorldMatrix + "\n" +
        //     "otherPortalMat[4x4]:\n" + otherPortal.transform.worldToLocalMatrix + "\n" +
        //     "playerCamMat[4x4]:\n" + playerCam.transform.worldToLocalMatrix + "\n" +
        //     "resultMat[4x4]:\n" + m
        // );
        
        
        screen.enabled = true;
    }

    // private void Update()
    // {
    //     //var cam = otherPortal.GetComponent(typeof(Camera));
    //     
    //     var pos = initOtherPortalCamPos + playerCam.transform.position;
    //     var transform1 = otherPortal.transform;
    //     transform1.position = new Vector3(pos.x, transform1.position.y, pos.z);
    //     //transform1.position = 
    // }
    
}