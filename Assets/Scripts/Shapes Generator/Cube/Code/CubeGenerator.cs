using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMathTools;


public class CubeGenerator : MonoBehaviour
{


    MeshFilter m_Mf;
    [SerializeField] float size=1;



    public void Process()
    {
        m_Mf = GetComponent<MeshFilter>();


        m_Mf.sharedMesh = GenerateCube(size);


        // Add a Mesh Collider if there is not any
        if (gameObject.GetComponent<MeshCollider>() == null){
          gameObject.AddComponent<MeshCollider>();
        }


        // Set the new mesh as collider
        gameObject.GetComponent<MeshCollider>().sharedMesh = null;
        gameObject.GetComponent<MeshCollider>().sharedMesh = m_Mf.sharedMesh;




    }

    Mesh GenerateCube(float size)
    {
      Mesh mesh = new Mesh();
      mesh.name = "Cube";

      mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

      float halfSize = size * .5f;

      Vector3[] vertices = new Vector3[8];
      int[] triangles = new int[6*2*3];
      Vector2[] uv = new Vector2[vertices.Length];


      //vertices
      int index_vertices = 0;

      vertices[index_vertices++] = new Vector3(-halfSize, -halfSize, -halfSize);
      vertices[index_vertices++] = new Vector3(-halfSize, -halfSize, halfSize);
      vertices[index_vertices++] = new Vector3(halfSize, -halfSize, -halfSize);
      vertices[index_vertices++] = new Vector3(halfSize, -halfSize, halfSize);

      vertices[index_vertices++] = new Vector3(halfSize, halfSize, -halfSize);
      vertices[index_vertices++] = new Vector3(halfSize, halfSize, halfSize);
      vertices[index_vertices++] = new Vector3(-halfSize, halfSize, -halfSize);
      vertices[index_vertices++] = new Vector3(-halfSize, halfSize, halfSize);

      //8 first triangles
      int index = 0;

      for (int i = 0; i<4;i++){
              // 1st triangle of the face
              triangles[index++] = (0 + i*2)%8;
              triangles[index++] = (2+ i*2)%8;
              triangles[index++] = (1+ i*2)%8;


              //2nd triangle of the face
              triangles[index++] = (2+ i*2)%8;
              triangles[index++] = (3+ i*2)%8;
              triangles[index++] = (1+ i*2)%8;
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




      mesh.vertices = vertices;
      mesh.triangles = triangles;
      mesh.uv = uv;
      //mesh.normals = normals;

      mesh.RecalculateNormals();
      mesh.RecalculateBounds();

      return mesh;
  }
}
