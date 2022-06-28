using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRKL.VR.Behaviour;

namespace VR.Scripts.Behaviours.Collision
{
    public class LoadSceneCollider : AbstractCollider
    {
        /// <summary>
        /// Radialbar zum Anzeigen des Ladefortschritts.
        /// </summary>
        [SerializeField]
        private readonly Image _radialBar;
        //private AsyncOperation asyncLoad;//AsyncOperation zum späteren Laden der entsprechenden Szenen.

        /// <summary>
        /// Partikelsystem, damit der Benutzer mitbekommt, ob dieser das richtige Objekt hinzugefügt hat.
        /// </summary>
        [SerializeField]
        public ParticleSystem mTrueOrFalse;

        /// <summary>
        /// Particle System Emmision
        /// </summary>
        private ParticleSystem.EmissionModule _emission;

        /// <summary>
        /// Label unterhalb der X-Stelle.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI loadingLabel;

        /// <summary>
        /// Gibt an, welche Szene nachher geladen werden soll.
        /// </summary>
        private string _sceneToLoad = string.Empty;


        /// <summary>
        /// Private Hilfsvariable für <see cref="IsLoading"/>
        /// </summary>
        private bool _isLoading;

        

        /// <summary>
        /// Gibt an, ob im Moment eine Szene geladen wird.
        /// </summary>
        public bool IsLoading { get => _isLoading; set => _isLoading = value; }


        private void Awake()
        {
            _emission = mTrueOrFalse.emission;
            _emission.enabled = false;
        }

        private void Start()
        {
            _radialBar.fillAmount = 0f;
        }

        /// <summary>
        /// Bei dieser Triggerabfrage, wird überprüft, ob das eintretende Objekt ein GameObject mit dem Tag "SceneGlobe" ist. 
        /// GameObjects mit dem Tag "SceneGlobe" sind zumeist eine modellierte Schneekugel mit einem Miniatur Modell zur Darstellung der auszuführenden Anwendung.
        /// Außerdem enthält der Name des GameObjects den Namen der Szene, die ausgeführt werden soll. Bitte darauf achten, dass die Szene in den Build Settings festgelegt ist.
        /// Denn nur diese speziellen GameObjects sollen im nächsten Schritt die Szene (Anhand des Namens des GameObjects) mit einer AsyncOperation gestartet werden.
        /// </summary>
        /// <param name="other">Beschreibt das in den Collider eingetretene GameObject</param>
        protected override void OnTriggerEnter(Collider other)
        {
            // Es handelt sich bei dem GameObject um eine Schneekugel samt kleinem Modell.
            // Außerdem wurde das Laden einer Szene noch nicht gestartet.
            if (other.gameObject.tag == "SceneGlobe" && !IsLoading)
            {
                IsLoading = true;

                var main = mTrueOrFalse.main;
                main.startColor = Color.green;
                _emission.enabled = true;
                _sceneToLoad = other.gameObject.name;
                loadingLabel.text = "Loading " + other.gameObject.name + " Scenario";
                StartCoroutine(LoadScence());
            }
            else if (other.gameObject.tag == "SceneGlobe" && IsLoading)//Es handelt sich bei dem GameObject um eine Schneekugel, doch es wurde schon eine Szene geladen. Deswegen wird nichts ausgeführt!
            {
                return;
            }
            else//Es handelt sich um keine Schneekugel, dem Benutzer wird das durch ein rotes Partikelsystem und durch das Ändern des Labels dargestellt.
            {
                var main = mTrueOrFalse.main;
                main.startColor = Color.red;
                _emission.enabled = true;
                loadingLabel.text = "Only a globe will work!";

            }
        }
        /// <summary>
        /// Der Benutzer verlässt mit seinem Controller den Collider der X-Stelle.
        /// </summary>
        /// <param name="other"> Das GameObject, dass den Collider verlässt.</param>
        protected override void OnTriggerExit(Collider other)
        {
            if (IsLoading)//Wenn eine Szene geladen wird wird nichts ausgeführt.
                return;
            else//Wenn nichts geladen wird, sich also auch keine Schneekugel auf der X-Stelle befindet, wird wieder der Standard Text des Labels angezeigt.
            {
                loadingLabel.text = "Place Scenario here";
                mTrueOrFalse.Stop();
            }

        }


        /// <summary>
        /// Enumerator zum Laden der zuvor in OnTriggerEnter festgelegten Szene. Hierbei wird kontinuierlich die Radial Progressbar, die sich auf dem "Table" Mesh befindet
        /// aktualisiert. Die Werte basiAsyncdabei auf dem FortsasyncOperatioSceneManager.dens.
        ///</summary>
        /// <returns></returns>    
        IEnumerator LoadScence()
        {
            SceneManager.LoadScene(this._sceneToLoad);
            yield return null;
        }

    }
}
