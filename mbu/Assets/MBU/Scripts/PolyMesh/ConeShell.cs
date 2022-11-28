using UnityEngine;

// Namespace
namespace VRKL.MBU
{
    /// <summary>
    /// Kegelmantel als Instanz von PolyMesh.
    /// </summary>
    /// <remarks>
    /// Wir realisieren den Kegelmantel als Triangle Fan.
    ///
    /// Die Grundfläche des Kegels liegt in der xz-Ebene
    /// und wird nicht gerendert.
    /// Die Topologie dieses Netzes ist identisch mit der
    /// Topologie in der Klasse CircularSurface.
    /// Der Mittelpunkt des Fans liegt jetzt in der Spitze
    /// des Kegels.  Wir berechnen hier die Normalen mit Hilfe
    /// der Basisklasse.
    ///
    /// Der scalingFactor in der Basisklasse wird als Wert
    /// für den Radius verwendet.
    ///
    /// Für den Boden, falls er benötigt wird, verwenden wir
    /// die Klasse CircularSurface.
    /// </remarks>
    public class ConeShell : PolyMesh
    {
        [Tooltip("Höhe des Kegels")]
        /// <summary>
        /// Höhe für den Kegelmantel.
        /// </summary>
        /// <remarks>
        /// Default ist 2.0.
        /// </remarks>
        public float Height = 2.0f;
        
        [Tooltip("Anzahl der Punkte auf dem Kreis")]
        /// <summary>
        /// Auflösung der Punkte auf dem Kreis.
        /// </summary>
        /// <remarks>
        /// Default ist 64.
        /// </remarks>
        public int NumberOfPoints = 64;
       
        /// <summary>
        /// Berechnung von Geometrie und Topologie und
        /// Übergabe der Daten an die Basisklasse PolyMesh.
        /// </summary>
        protected override void Create()
        {
            /// Anzahl Eckpunkte ist Auflösung + Mittelpunkt
            var numberOfVertices = NumberOfPoints + 1;
            /// Wir haben soviel Dreiecke wie Punkte auf dem Kreis
            var numberOfSubMeshes = NumberOfPoints;
            var vertices = new Vector3[numberOfVertices];
            // Eckennormalen
            var topology = new int[numberOfSubMeshes][];
            var materials = new Material[numberOfSubMeshes];

            // Berechnung der Punkte auf dem Kreis.
            // Mittelpunkt ist der erste Punkt.
            vertices[0] = Vector3.zero;
            vertices[0].y = Height;
            var deltaPhi = (2.0f * Mathf.PI) / NumberOfPoints;
            var phi = 0.0f;
            for (var i = 1; i < numberOfVertices; i++)
            {
                vertices[i].x = ScalingFactor * Mathf.Cos(phi);
                vertices[i].y = 0.0f;
                vertices[i].z = - ScalingFactor * Mathf.Sin(phi);
                phi += deltaPhi;
            }

            // Die Einträge in der Topologie beziehen sich auf 
            // die Indizes der Eckpunkte.
           for (var i = 0; i < NumberOfPoints-1; i++)
           {
                topology[i] = new int[3] { 0, i+1, i+2 };
           }

            // Letzes Dreieck außerhalb der for-Schleife
            topology[NumberOfPoints-1] = new int[3] {0, NumberOfPoints, 1};

            // Polygonales Netz erzeugen, Geometrie und Topologie zuweisen
            // Es wäre möglich weniger als vier SubMeshes zu erzeugen,
            // solange wir keine Dreiecke in einem Submesh haben, die eine
            // gemeinsame Kante aufweisen!
            var simpleMesh = new Mesh()
            {
                vertices = vertices,
                subMeshCount = numberOfSubMeshes
            };

            var mat = CreateMaterial();
            for (var i = 0; i < numberOfSubMeshes; i++)
            {
                simpleMesh.SetTriangles(topology[i], i);
                materials[i] = mat;
            }

            // Unity die Normalenvektoren und die Bounding-Box berechnen lassen.
            simpleMesh.RecalculateNormals();
            simpleMesh.RecalculateBounds();
            simpleMesh.OptimizeIndexBuffers();

            // Zuweisungen für die erzeugten Komponenten
            this.objectFilter.mesh = simpleMesh;
            this.objectRenderer.materials = materials;
        }
    }
}
