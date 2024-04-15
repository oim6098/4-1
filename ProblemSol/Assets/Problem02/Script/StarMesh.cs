using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class StarMesh : MonoBehaviour
{
    public int points = 5;
    public float outerRadius = 1f;
    public float innerRadius = 0.5f;

    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // 꼭짓점과 삼각형 배열을 생성합니다.
        Vector3[] vertices = new Vector3[points * 2];
        int[] triangles = new int[points * 3 * 2];

        // 꼭짓점을 설정합니다.
        for (int i = 0; i < points * 2; i++)
        {
            float angle = (i * 2 * Mathf.PI) / (points * 2);
            float radius = i % 2 == 0 ? outerRadius : innerRadius;
            vertices[i] = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        }

        // 삼각형을 설정합니다.
        for (int i = 0; i < points * 2; i++)
        {
            int nextIndex = (i + 1) % (points * 2);
            int nextNextIndex = (i + 2) % (points * 2);
            triangles[i * 3] = i;
            triangles[i * 3 + 1] = nextIndex;
            triangles[i * 3 + 2] = nextNextIndex;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
