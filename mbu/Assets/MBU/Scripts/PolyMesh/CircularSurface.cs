using UnityEngine;

// Namespace
namespace VRKL.MBU
{
    /// <summary>
    /// Kreisfl�che als Instanz von PolyMesh.
    /// </summary>
    /// <remarks>
    /// Die Kreisfl�che wird als Triangle Fan realisiert.
    ///
    /// Als Default-Lage liegt die Fl�che in der xz-Ebene,
    /// die Vorderseite ist in positiver y-Richtung.
    ///
    /// Der scalingFactor in der Basisklasse wird als Wert
    /// f�r den Radius verwendet.
    /// </remarks>
    public class CircularSurface : PolyMesh
    {
        [Tooltip("Anzahl der Punkte auf dem Kreis")]
        /// <summary>
        /// Aufl�sung der Punkte auf dem Kreis.
        /// </summary>
        /// <remarks>
        /// Default ist 64.
        /// </remarks>
        public int NumberOfPoints = 64;
       
        /// <summary>
        /// Berechnung von Geometrie und Topologie und
        /// �bergabe der Daten an die Basisklasse PolyMesh.
        /// </summary>
        protected override void Create()
        {
            /// Anzahl Eckpunkte ist Aufl�sung + Mittelpunkt
            var numberOfVertices = NumberOfPoints + 1;
            /// Wir haben soviel Dreiecke wie Punkte auf dem Kreis
            var numberOfSubMeshes = NumberOfPoints;
            var vertices = new Vector3[numberOfVertices];
            // Eckennormalen
            var normal = new Vector3[numberOfVertices];
            var topology = new int[numberOfSubMeshes][];
            var materials = new Material[numberOfSubMeshes];

            // Berechnung der Punkte auf dem Kreis.
            // Mittelpunkt ist der erste Punkt.
            vertices[0] = Vector3.zero;
            normal[0] = Vector3.up;
            var deltaPhi = (2.0f * Mathf.PI) / NumberOfPoints;
            var phi = 0.0f;
            for (var i = 1; i < numberOfVertices; i++)
            {
                vertices[i].x = ScalingFactor * Mathf.Cos(phi);
                vertices[i].y = 0.0f;
                vertices[i].z = - ScalingFactor * Mathf.Sin(phi);
                normal[i] = Vector3.up;
                phi += deltaPhi;
            }

            // Die Eintr�ge in der Topologie beziehen sich auf 
            // die Indizes der Eckpunkte.
           for (var i = 0; i < NumberOfPoints-1; i++)
           {
                topology[i] = new int[3] { 0, i+1, i+2 };
           }

            // Letzes Dreieck au�erhalb der for-Schleife
            topology[NumberOfPoints-1] = new int[3] {0, NumberOfPoints, 1};

            // Polygonales Netz erzeugen, Geometrie und Topologie zuweisen
            // Es w�re m�glich weniger als vier SubMeshes zu erzeugen,
            // solange wir keine Dreiecke in einem Submesh haben, die eine
            // gemeinsame Kante aufweisen!
            var simpleMesh = new Mesh()
            {
                vertices = vertices,
                normals = normal,
                subMeshCount = numberOfSubMeshes
            };

            var mat = CreateMaterial();
            for (var i = 0; i < numberOfSubMeshes; i++)
            {
                simpleMesh.SetTriangles(topology[i], i);
                materials[i] = mat;
            }

            // Unity die  Bounding-Box berechnen lassen.
            // Normalen wurden in dieser Klasse selbst berechnet.
            simpleMesh.RecalculateBounds();
            simpleMesh.OptimizeIndexBuffers();

            // Zuweisungen f�r die erzeugten Komponenten
            this.objectFilter.mesh = simpleMesh;
            this.objectRenderer.materials = materials;
        }
    }
}