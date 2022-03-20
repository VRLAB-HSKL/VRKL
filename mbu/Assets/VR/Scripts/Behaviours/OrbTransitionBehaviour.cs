using System;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR.Scripts.Behaviours.Button
{
    public class OrbTransitionBehaviour : MonoBehaviour
    {
        public GameObject Orb;
    
        public int targetSceneIndex;

        public void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (collision.gameObject == Orb)
            {
                PlayTransition();
            }
        }

        public void PlayTransition()
        {
            SceneManager.LoadSceneAsync(targetSceneIndex);
        }

    }
}