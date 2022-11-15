using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMathTools;


public class BoxGenerator : MonoBehaviour
{


    MeshFilter m_Mf;
    [SerializeField] float size=1;
    [SerializeField] float height = 0.2f;



    public void Process()
    {
        m_Mf = GetComponent<MeshFilter>();


        m_Mf.sharedMesh = GenerateBox(size, height);


        // Add a Mesh Collider if there is not any
        if (gameObject.GetComponent<MeshCollider>() == null){
          gameObject.AddComponent<MeshCollider>();
        }


        // Set the new mesh as collider
        gameObject.GetComponent<MeshCollider>().sharedMesh = null;
        gameObject.GetComponent<MeshCollider>().sharedMesh = m_Mf.sharedMesh;




    }

    Mesh GenerateBox(float size, float height)
    {
      Mesh mesh = new Mesh();
      mesh.name = "Box";

      mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

      float halfSize = size * .5f;

      Vector3[] vertices = new Vector3[8];
      int[] triangles = new int[5*2*3*2];
      Vector2[] uv = new Vector2[vertices.Length];


      //vertices
      int index_vertices = 0;

      vertices[index_vertices++] = new Vector3(-halfSize, -height/2, -halfSize);
      vertices[index_vertices++] = new Vector3(-halfSize, -height/2, halfSize);
      vertices[index_vertices++] = new Vector3(halfSize, -height/2, -halfSize);
      vertices[index_vertices++] = new Vector3(halfSize, -height/2, halfSize);

      vertices[index_vertices++] = new Vector3(halfSize, height/2, -halfSize);
      vertices[index_vertices++] = new Vector3(halfSize, height/2, halfSize);
      vertices[index_vertices++] = new Vector3(-halfSize, height/2, -halfSize);
      vertices[index_vertices++] = new Vector3(-halfSize, height/2, halfSize);

      //8 first triangles
      int index = 0;

      for (int i = 0; i<4;i++){
        if (i != 2){ // We skip the top lid
              // First side of the face
              triangles[index++] = (0 + i*2)%8;
              triangles[index++] = (1+ i*2)%8;
              triangles[index++] = (2+ i*2)%8;

              triangles[index++] = (2+ i*2)%8;
              triangles[index++] = (1+ i*2)%8;
              triangles[index++] = (3+ i*2)%8;
        }

      }


      // 4 last triangles
      triangles[index++] = 7;
      triangles[index++] = 3;
      triangles[index++] = 5;

      triangles[index++] = 7;
      triangles[index++] = 1;
      triangles[index++] = 3;

      triangles[index++] = 4;
      triangles[index++] = 2;
      triangles[index++] = 6;

      triangles[index++] = 6;
      triangles[index++] = 2;
      triangles[index++] = 0;

      triangles[index++] = 7;
      triangles[index++] = 5;
      triangles[index++] = 3;

      triangles[index++] = 7;
      triangles[index++] = 3;
      triangles[index++] = 1;

      triangles[index++] = 4;
      triangles[index++] = 6;
      triangles[index++] = 2;

      triangles[index++] = 6;
      triangles[index++] = 0;
      triangles[index++] = 2;




      mesh.vertices = vertices;
      mesh.triangles = triangles;
      mesh.uv = uv;

      mesh.RecalculateNormals();
      mesh.RecalculateBounds();

      return mesh;
  }
}
