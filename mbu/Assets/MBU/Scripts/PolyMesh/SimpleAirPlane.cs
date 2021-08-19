using UnityEngine;
using System.Collections;
using VRKL.MBU;

/// <summary>
/// Ein einfaches Modell eines Flugzeugs
/// 
/// Dieses Modell ist eine Unity-Vesion des 
/// Flugzeugmodells, das in VTK für die Visualisierung
/// der Animation von Rotationen im Computergrafik-Buch
/// realisiert wurde. Die hier verwendeten Dreiecke verwenden
/// ein linkshändiges Koordinatensystem
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

public class SimpleAirPlane : PolyMesh
{
    /// <summary>
    /// Faktor für eine gleichmässige Skalierung des Modells.
    /// </summary>
    [Range(0.05f, 1.5f)]
    [Tooltip("Skalierungsfaktor\\Das Modell ist 6 m lang und jeweils 1 m hoch und breit")]
    public float Factor = 1.0f;

    /// <summary>
    /// Wir speichern die Geometrie und die Topologie des Dreiecks ab
    /// und legen die Daten in eine Instanz der Klaasse Mesh.
    /// </summary>
    protected override void Create()
    {
        // Die Daten für die Eckpunkte stammen aus der Datei
        // plane.vtk, die beim Schreiben des Buchs "Computergrafik"
        // für die Demonstration von Rotationen und Quaternionen
        // verwendet wurde.
        Vector3[] vertices = new Vector3[20];
        vertices[0] = new Vector3( 0.0f,  0.0f,  4.5f);
        vertices[1] = new Vector3( 1.0f,  1.0f,  3.0f);
        vertices[2] = new Vector3(-1.0f,  1.0f,  3.0f);
        vertices[3] = new Vector3(-1.0f, -1.0f,  3.0f);
        vertices[4] = new Vector3( 1.0f, -1.0f,  3.0f);
        vertices[5] = new Vector3( 1.0f,  1.0f, -3.0f);
        vertices[6] = new Vector3(-1.0f,  1.0f, -3.0f);
        vertices[7] = new Vector3(-1.0f, -1.0f, -3.0f);
        vertices[8] = new Vector3( 1.0f, -1.0f, -3.0f);
        // Flügel rechts
        vertices[9] = new Vector3(  1.0f,  0.0f,  2.0f);
        vertices[10] = new Vector3( 1.0f,  0.0f,  0.0f);
        vertices[11] = new Vector3( 5.0f,  0.0f,  0.0f);
        vertices[12] = new Vector3( 5.0f,  0.0f,  1.0f);
        // Flügel links
        vertices[13] = new Vector3(-1.0f, 0.0f, 2.0f);
        vertices[14] = new Vector3(-1.0f, 0.0f, 0.0f);
        vertices[15] = new Vector3(-5.0f, 0.0f, 0.0f);
        vertices[16] = new Vector3(-5.0f, 0.0f, 1.0f);
        // Leitwerk
        vertices[17] = new Vector3( 0.0f, 0.0f,-3.0f);
        vertices[18] = new Vector3( 0.0f, 0.0f,-1.0f);
        vertices[19] = new Vector3( 0.0f, 3.0f, -3.0f);

        for (int i=0; i<vertices.Length; i++)
        {
            vertices[i] = Factor * vertices[i];
        }

        // Die Einträge in der Topologie beziehen sich auf 
        // die Indizes der Eckpunkte.
        // Die Durchlaufrichtung der Indices ist wichtig, da sonst
        // bei Backface Culling die Dreiecke nicht dargestellt werden.
        // Unity definiert ein Frontface als ein Polygon, das 
        // im Uhrzeigersinn durchlaufen wird!
        int[] topology = new int[72];

        topology[0] = 0;
        topology[1] = 1;
        topology[2] = 2;

        topology[3] = 0;
        topology[4] = 2;
        topology[5] = 3;

        topology[6] = 0;
        topology[7] = 3;
        topology[8] = 4;

        topology[9] = 0;
        topology[10] = 4;
        topology[11] = 1;

        topology[12] = 3;
        topology[13] = 8;
        topology[14] = 4;

        topology[15] = 3;
        topology[16] = 7;
        topology[17] = 8;

        topology[18] = 1;
        topology[19] = 5;
        topology[20] = 2;

        topology[21] = 2;
        topology[22] = 5;
        topology[23] = 6;

        topology[24] = 1;
        topology[25] = 4;
        topology[26] = 8;

        topology[27] = 1;
        topology[28] = 8;
        topology[29] = 5;

        topology[30] = 2;
        topology[31] = 7;
        topology[32] = 3;

        topology[33] = 2;
        topology[34] = 6;
        topology[35] = 7;

        topology[36] = 5;
        topology[37] = 8;
        topology[38] = 7;

        topology[39] = 5;
        topology[40] = 7;
        topology[41] = 6;

        // Flügel rechts
        topology[42] = 10;
        topology[43] = 12;
        topology[44] = 11;

        topology[45] = 9;
        topology[46] = 12;
        topology[47] = 10;

        // Flügel links
        topology[48] = 14;
        topology[49] = 15;
        topology[50] = 16;

        topology[51] = 13;
        topology[52] = 14;
        topology[53] = 16;

        // Leitwerk
        topology[54] = 17;
        topology[55] = 19;
        topology[56] = 18;

        // Flügel und Leitwerk auch im umgedrehten Reihenfolge,
        // so erhalten wir doppelseitige Anzeige.
        // Flügel rechts
        topology[57] = 10;
        topology[58] = 11;
        topology[59] = 12;

        topology[60] = 9;
        topology[61] = 10;
        topology[62] = 12;

        // Flügel links
        topology[63] = 14;
        topology[64] = 16;
        topology[65] = 15;

        topology[66] = 13;
        topology[67] = 16;
        topology[68] = 14;

        // Leitwerk
        topology[69] = 17;
        topology[70] = 18;
        topology[71] = 19;

        Material[] materials = new Material[1];

        // Polygonales Netz erzeugen, Geometrie und Topologie zuweisen
        Mesh simpleMesh = new Mesh()
        {
            vertices = vertices,
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
