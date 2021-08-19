using UnityEngine;
using System.Collections;

/// <summary>
/// Ein einfaches polygonales Netz erzeugen
/// 
/// Verwendung: ein leeres GameObject im Editor erzeugen
/// und dieses Skript diesem GameObject hinzufügen.
/// Das polygonale Netz wird als Instanz der Klasse PolyMesh
/// erzeugt.
/// Anschließend können wir dem GameObject ein Material zuweisen.
/// 
/// Bei der Ausführung der Anwendung wird das polygonale Netz
/// erstellt und dargestellt.
/// </summary>

public class SimpleMesh : VRKL.MBU.PolyMesh
{
    /// <summary>
    /// Wir speichern die Geometrie und die Topologie des Dreiecks ab
    /// und legen die Daten in eine Instanz der Klaasse Mesh.
    /// </summary>
    protected override void Create()
    {
        // Wir stellen ein Dreieck dar.
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(-1.0f, 0.0f, 3.0f);
        vertices[1] = new Vector3(-1.0f, 0.5f, 3.0f);
        vertices[2] = new Vector3(0.0f, 0.0f, 2.0f);

        // Die Einträge in der Topologie beziehen sich auf 
        // die Indizes der Eckpunkte.
        // Die Durchlaufrichtung der Indices ist wichtig, da sonst
        // bei Backface Culling die Dreiecke nicht dargestellt werden.
        // Unity definiert ein Frontface als ein Polygon, das 
        // im Uhrzeigersinn durchlaufen wird!
        int[] topology = new int[3];

        topology[0] = 0;
        topology[1] = 1;
        topology[2] = 2;

        Material[] materials = new Material[1];

        // Polygonales Netz erzeugen, Geometrie und Topologie zuweisen
        Mesh simpleMesh = new Mesh()
        {
            vertices = vertices,
            subMeshCount = 1,
            triangles = topology
        };

        // Wir nutzen nicht aus, dass wir pro Submesh ein eigenes
        // Material verwenden.
        materials[0] = meshMaterial;

        // Unity die Normalenvektoren und die Bounding-Box berechnen lassen.
        simpleMesh.RecalculateNormals();
        simpleMesh.RecalculateBounds();
        simpleMesh.OptimizeIndexBuffers();

        // Zuweisungen für die erzeugten Komponenten
        objectFilter.mesh = simpleMesh;
        objectRenderer.materials = materials;
    }
}
