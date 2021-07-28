//========= 2021 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Examine-Metapher
    /// 
    /// Die Klasse verwendet die Renderer-Komponente
    /// einer plane, die in Start erzeugt wird. 
    /// Als Ursprung der Rotationen wird das Zentrum dieser
    /// Plane verwendet, die nicht dargestellt wird.
    /// <remarks>
    /// Mehr zur Examine-Metapher findet man in
    /// Michael Bender, Manfred Brill: "Computergrafik",
    /// Hanser Verlag, 2005.
    /// </remarks>
    /// </summary>
    [AddComponentMenu("MBU/Examine")]
     public class Examine : MonoBehaviour
     {
        /// <summary>
        /// Welches Objekt wollen wir untersuchen?
        /// 
        /// Voraussetzung für diese Klasse ist, dass das beobachtete Objekt
        /// einen Renderer besitzt. Wir verwenden den Mittelpunkt
        /// der axis-aligned BBox, die der Unity-Renderer erzeugt, als 
        /// Ursprung unseres Examine-Koordinatensystems.
        /// 
        /// Die Anwendung ist dafür verantwortlich, dass die Kameraposition
        /// korrekt eingestellt ist.
        /// </summary>

        /// <summary>
        /// Wir erzeugen eine Plane, der wir einen renderer hinzufügen. 
        /// <summary>
        private GameObject _plane;

        /// Differenz des Rotationswinkels, falls ein Event 
        /// auftritt in Gradmaß.
        /// </summary>
        [Range(0.1f, 10.0f)]
        [Tooltip("Veränderung der Rotationswinkel")]
        public float delta = 0.5f;

        /// <summary>
        /// Taste für "Reset"
        /// 
        /// Default ist R.
        /// </summary>
        [Tooltip("Reset-Taste")]
        public KeyCode resetB = KeyCode.R;
        /// <summary>
        /// Taste für "Links"
        /// 
        /// Default ist A.
        /// </summary>
        [Tooltip("Taste für das nach links")]
        public KeyCode leftB = KeyCode.A;
        /// <summary>
        /// Taste für "Rechts"
        /// 
        /// Default ist D.
        /// </summary>
        [Tooltip("Taste für das nach rechts")]
        public KeyCode rightB = KeyCode.D;
        /// <summary>
        /// Taste für "Oben"
        /// 
        /// Default ist W.
        /// </summary>
        [Tooltip("Taste für das nach oben")]
        public KeyCode upB = KeyCode.W;
        /// <summary>
        /// Taste für "Unten"
        /// 
        /// Default ist X.
        /// </summary>
        [Tooltip("Taste für das nach unten")]
        public KeyCode downB = KeyCode.X;

        /// <summary>
        /// Instanz des Renderers.
        /// 
        /// Wir benötigen diese Instanz, um die Bounding-box abzufragen.
        /// </summary>
        private Renderer Ren;

        /// <summary>
        /// Um welchen Punkt in Weltkoordinaten rotiert die Kamera?
        /// <remarks>
        /// Wir verwenden das Zentrum des Colliders, der zu diesem
        /// Objekt gehört.
        /// </remarks>
        /// </summary>
        private Vector3 RotationPoint;

        /// <summary>
        /// Wir verwenden die AABB einer plane, die wir hier erzeugen
        /// und fragen davon das Zentrum ab. Diesen Punkt
        /// verwenden wir als Ursprung unseres Examine-Koordinatensystems.
        /// </summary>
        void Start()
        {
            _plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Ren= _plane.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
            Ren.enabled = false;
            RotationPoint = Ren.bounds.center;
        }

        /// <summary>
        /// Rotation der Kamera um das festgelegte Zentrum,
        /// um die x- bzw. y-Achse.
        /// <remarks>
        /// Mit leftB drehen wir mathematisch positiv,
        /// mit rightb mathematisch negativ um die y-Achse.
        /// 
        /// Analog drehen wir mit upB mathematik positiv,
        /// mit downB mathematik negativ um die x-Achse.
        /// </remarks>
        /// </summary>
        void Update()
        {
            if (Input.GetKey(resetB))
                transform.localRotation = Quaternion.identity;
            if (Input.GetKey(leftB))
                rotateUpAxis(-delta);
            if (Input.GetKey(rightB))
                rotateUpAxis(delta);
            if (Input.GetKey(upB))
                rotateRightAxis(-delta);
            if (Input.GetKey(downB))
                rotateRightAxis(delta);
        }

        /// <summary>
        /// In Unity ist die y-Achse die Up-Axis.
        /// </summary>
        /// <param name="angle">Drehwinkel in Gradmaß</param>
        private void rotateUpAxis(float angle)
        {
            transform.RotateAround(RotationPoint, Vector3.up, angle);
        }
        /// <summary>
        /// In Unity ist die x-Achse die Right-Axis.
        /// </summary>
        /// <param name="angle">Drehwinkel in Gradmaß</param>
        private void rotateRightAxis(float angle)
        {
            transform.RotateAround(RotationPoint, Vector3.right, angle);
        }
    }
}
