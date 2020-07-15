//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace für allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Examine-Metapher aus der Computergrafik.
    /// Drehungen um die x- und die y-Achse eines Objekts.
    /// 
    /// Die C#-Klasse verwendet die Renderer-Komponente
    /// des untersuchten GameObjects. Dies wird durch
    /// <code>RequireComponent</code> sicher gestellt.
    /// <remarks>
    /// Mehr zur Examine-Metapher findet man in
    /// Michael Bender, Manfred Brill: "Computergrafik",
    /// Hanser Verlag, 2005.
    /// </remarks>
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    public class Examine : MonoBehaviour
    {
        /// <summary>
        /// Welches Objekt wollen wir untersuchen?
        /// 
        /// Voraussetzung für diese Klasse ist, dass das beobachtete Objekt
        /// einen Renderer besitzt. Wir verwenden den Mittelpunkt
        /// der axis-aligned BBox, die der Unity-Renderer erzeugt, als 
        /// Ursprung unseres Examine-Koordinatensystems.
        /// </summary>

        /// <summary>
        /// Differenz des Rotationswinkels, falls ein Event 
        /// auftritt in Gradmaß.
        /// </summary>
        [Range(0.1f, 10.0f)]
        [Tooltip("Veränderung der Rotationswinkel")]
        public float delta = 1.0f;

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
        /// Wir verwenden die AABB, die der Renderer für das Objekt
        /// erzeugt und fragen das Zentrum ab. Diesen Punkt
        /// verwenden wir als Ursprung unseres Examine-Koordinatensystems.
        /// </summary>
        void Start()
        {
            Ren = GetComponent<Renderer>();
            RotationPoint = Ren.bounds.center;
        }

        /// <summary>
        /// Rotation der Kamera um das festgelegte Zentrum,
        /// um die x- bzw. y-Achse.
        /// <remarks>
        /// Mit "A" oder Cursor nach links drehen wir positiv,
        /// mit "D" oder Cursor nach rechts drehen wir negativ.
        /// </remarks>
        /// </summary>
        void Update()
        {
            if (Input.GetKey(KeyCode.R))
                transform.localRotation = Quaternion.identity;
            if (Input.GetKey(KeyCode.A))
                rotateUpAxis(delta);
            if (Input.GetKey(KeyCode.D))
                rotateUpAxis(-delta);
            if (Input.GetKey(KeyCode.W))
                rotateRightAxis(delta);
            if (Input.GetKey(KeyCode.X))
                rotateRightAxis(-delta);
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
