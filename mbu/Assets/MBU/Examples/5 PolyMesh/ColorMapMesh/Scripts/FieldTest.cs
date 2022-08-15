using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]

public class FieldTest : VRKL.MBU.PolyMesh
{
    /// <summary>
    /// Variable für die Bitmap, deren Name wir
    /// im Inspektor angeben können.
    /// </summary>
    public string m_cmName = "YlOrRd";

    /// <summary>
        /// Das polygonale Netz wird in der abgeleiteten Klasse
        /// mit Hilfe der Funktion Create erzeugt!
        /// </summary>
        protected override void Create()
        { 
            const int numberOfVertices = 10;
            const int numberOfTriangles = 8;
            Vector3[] vertices = new Vector3[numberOfVertices];
            //Vector3[] normals  = new Vector3[numberOfVertices];
            Vector2[] uvs = new Vector2[numberOfVertices];
            int[] topology = new int[3*numberOfTriangles];
            Material[] materials = new Material[numberOfTriangles];
            // Instanz der Klasse Mesh
            Mesh simpleMesh;

            // Shader-Kategorie auf Texture stellen!
            m_ShaderName = "Unlit/Texture";

            float zMin = 0.0f;
            float zMax = 1.0f;

          // Eckpunkte
          vertices[0] = new Vector3(-1.0f, 0.0f, zMin);
          vertices[1] = new Vector3(-1.0f, 0.1f, zMax);
          vertices[2] = new Vector3(0.0f, 0.4f, zMin);
          vertices[3] = new Vector3(0.0f,  0.4f, zMax);
          vertices[4] = new Vector3(1.0f,  1.0f, zMin);
          vertices[5] = new Vector3(1.0f,  0.9f, zMax);
          vertices[6] = new Vector3(1.5f,  0.5f, zMin);
          vertices[7] = new Vector3(1.5f,  0.4f, zMax);
          vertices[8] = new Vector3(2.0f,  0.5f, zMin);
          vertices[9] = new Vector3(2.0f,  0.1f, zMax);

          // Skalare Werte für die Texturierung
          var min = 0.0f;
        var max =1.0f;
        for (var i = 0; i < numberOfVertices; i++)
            uvs[i] = new Vector2((vertices[i].y-min)/(max-min), 0.5f);
        
          // Topologie
          topology[0] = 0;
          topology[1] = 1;
          topology[2] = 2;

          topology[3] = 2;
          topology[4] = 1;
          topology[5] = 3;
        
          topology[6] = 2;
          topology[7] = 3;
          topology[8] = 4;
        
          topology[9] = 3;
          topology[10] = 5 ;
          topology[11] = 4;
        
          topology[12] = 4;
          topology[13] = 5;
          topology[14] = 6;
        
          topology[15] = 7;
          topology[16] = 6;
          topology[17] = 5;

          topology[18] = 6;
          topology[19] = 7;
          topology[20] = 8;
      
          topology[21] = 9;
          topology[22] = 8;
          topology[23] = 7;
          
          // Polygonales Netz erzeugen, Geometrie und Topologie zuweisen
          simpleMesh = new Mesh
          {
              vertices = vertices,
              triangles = topology,
              uv = uvs,
              subMeshCount = numberOfTriangles,
          };

         
          // Wir speichern die png-Files in Resources/Textures.
          string fullName = "Textures/" + m_cmName;
          var texture = Resources.Load<Texture2D>(fullName) as Texture2D;
          texture.filterMode = FilterMode.Bilinear;
          texture.wrapModeU = TextureWrapMode.MirrorOnce;

          // Wir nutzen nicht aus, dass wir pro Submesh ein eigenes
          // Material verwenden.
          var mat = CreateMaterial();
          mat.mainTexture = texture;
          for (var i = 0; i < numberOfTriangles; i++)
          {
              materials[i] = mat;
          }
          
          // Unity die Normalenvektoren und die Bounding-Box berechnen lassen.
          simpleMesh.RecalculateNormals();
          simpleMesh.RecalculateBounds();
          simpleMesh.OptimizeIndexBuffers();

          // Zuweisungen für die erzeugten Komponenten
          objectFilter.mesh = simpleMesh;
          objectRenderer.materials = materials;
        }
        
    
}
