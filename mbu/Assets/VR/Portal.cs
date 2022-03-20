using System;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace VR
{
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


        private void Awake()
        {
            playerCam = Camera.main;
            portalCam = GetComponentInChildren<Camera>();
            //portalCam.enabled = false;
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
            
            // Make portal cam position and rotation the same relative to this portal as player cam relative to
            // other portal
            var m = transform.localToWorldMatrix *
                    otherPortal.transform.worldToLocalMatrix *
                    playerCam.transform.localToWorldMatrix;
            
            portalCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
            
            // Render the camera
            portalCam.Render();

            screen.enabled = true;
        }
    }
    
    
}