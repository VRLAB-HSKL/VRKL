//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace für allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Abstrakte Klasse für die Erzeugung eines polygonalen Netzes während der Laufzeit einer Anwendung
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [ExecuteInEditMode]
    public abstract class PolyMesh : MonoBehaviour
    {
        /// <summary>
        /// Wir erzeugen eine Material-Komponente,
        /// so dass wir im Editor dem Netz ein Material zuweisen können.
        /// </summary>
        [Tooltip("Material für die grafische Ausgabe des polygonalen Netzes")]
        public Material meshMaterial;

        /// <summary>
        /// Wir benötigen eine Instanz der Klasse MeshFilter.
        /// </summary>
        protected MeshFilter objectFilter;
        /// <summary>
        /// Mit Hilfe einer Instanz von MeshRenderer stellen wir den platonischen Körper dar.
        /// </summary>
        protected MeshRenderer objectRenderer;

        /// <summary>
        /// Anzahl der Eckpunkte
        /// </summary>
        public int NumberOfVertices
        {
            get { return _numberOfVertices; }
            set { _numberOfVertices = _numberOfVertices; }
        }
        private int _numberOfVertices { get; set; } = 0;

        /// <summary>
        /// Anzahl der Facetten (in Unity spricht man von Submeshes)
        /// </summary>
        public int NumberOfSubMeshes
        {
            get { return _numberOfSubMeshes; }
            set { _numberOfSubMeshes = _numberOfSubMeshes; }
        }
        private int _numberOfSubMeshes { get; set; } = 0;

        /// <summary>
        /// Das polygonale Netz wird in der abgeleiteten Klasse
        /// mit Hilfe der Funktion Create erzeugt!
        /// </summary>
        protected abstract void Create();

        protected virtual void Awake() { }

        /// <summary>
        /// MeshRenderer und MeshFilter zuordnen und Netz erzeugen.
        /// </summary>
        protected virtual void Start()
        {
            this.objectFilter = gameObject.GetComponent<MeshFilter>();
            this.objectRenderer = gameObject.GetComponent<MeshRenderer>();

            // Polygonales Netz erzeugen
            Create();
        }
    }
}
