using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;


    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;
    public Material material;
    public int xSize = 8;
    public int ySize = 8;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;
        CreateShape();
        UpdateMesh();
    }

    private void Update() {
        
    }

    void CreateShape() {
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        uv = new Vector2[(xSize + 1) * (ySize + 1)];
        

        int i = 0;
        for(int y = 0; y <= ySize; y++) {
            for(int x = 0; x <= xSize; x++) {
                vertices[i] = new Vector3(x*4, y*4);
                uv[i] = new Vector2(x * 4 * 0.032f, y * 4 * 0.032f);
                i++;
            }
        }

        triangles = new int[xSize * ySize * 6];
        int vert = 0;
        int tris = 0;

        for (int y = 0; y < ySize; y++) {
            for (int x = 0; x < xSize; x++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
        
    }

    void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        createBoxColliders2d();
    }

    void createBoxColliders2d() {
        BoxCollider2D[] box = new BoxCollider2D[(xSize) * (ySize)];
        int i = 0;
        for (int y = 0; y < ySize; y++) {
            for (int x = 0; x < xSize; x++) {
                box[i] = gameObject.AddComponent<BoxCollider2D>();
                box[i].size = new Vector2(4, 4);
                box[i].offset = new Vector2(2 + (x*4), 2 + (y*4));
                i++;
            }
        }
    }

}
