using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR.Scripts.Behaviours.Button
{
    public class FadeTransitionBehaviour : AbstractButtonBehaviour
    {
        private static GameObject instance;
        public static GameObject Instance => instance;
        public UnityEngine.UI.Image FadeImage;

        public int targetSceneIndex;
        
        public Animator animator;

        private int sourceSceneIndex;
        private int nextSceneIndex;
        private Vector3 initParentPos;
        private Color transitionColor = Color.black;
        private void Awake()
        {
            // Singleton between scenes
            if (instance == null)
            {
                instance = transform.parent.gameObject;
                DontDestroyOnLoad(instance);
                initParentPos = instance.transform.position;
                sourceSceneIndex = SceneManager.GetActiveScene().buildIndex;
                nextSceneIndex = targetSceneIndex;
            }
            else if (instance != transform.parent.gameObject)
            {
                // Destroy duplicate in new scene
                Destroy(transform.parent.gameObject);
            }
        }

        protected override void HandleButtonEvent()
        {
            //FadeToScene();
            StartCoroutine(LoadYourAsyncScene());
        }

        IEnumerator LoadYourAsyncScene()
        {
            FadeOut();
         
            // Wait until animation is finished
            while(animator.GetCurrentAnimatorStateInfo(0).IsName("Init"))
            {
                yield return null;
            }
            
            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.99f)
            {
                yield return null;
            }

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneIndex);

            // Wait until the asynchronous scene fully loads
            while (asyncLoad.progress < 1f || !asyncLoad.isDone)
            {
                // FadeImage.enabled = true;
                // FadeImage.color = transitionColor;
                //yield return null;
                
                yield return new WaitForSeconds(2);
            }

            FadeIn();
            MoveGameObjectInNewScene();
        }
        
        public void FadeIn()
        {
            animator.Play("Fade_In");
        }
        
        public void FadeOut()
        {
            animator.Play("Fade_Out");
        }

        private void MoveGameObjectInNewScene()
        {
            // Adjust position
            instance.transform.position = SceneManager.GetActiveScene().buildIndex != sourceSceneIndex ? 
                new Vector3(2f, 0f, 1f) : initParentPos;
            
            // Change next scene index
            var isInSourceRoom = nextSceneIndex != sourceSceneIndex;
            nextSceneIndex = isInSourceRoom ? sourceSceneIndex : targetSceneIndex;
        }
        
        
        
        
        
        
        
        
        
        
        
        
    }
}