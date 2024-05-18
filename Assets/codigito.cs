using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigito : MonoBehaviour
{
    private Vector3 center = Vector3.zero;
    public float radius = 1f;
    public int Vertices = 16;
    public Vector3 translation = Vector3.zero;
    public Vector3 scale = Vector3.one;
    private int segments = 0;
    void OnDrawGizmos()
    {
        segments = Vertices / 3;
        Vector3[] vertices = new Vector3[segments * (segments - 1) + 2];

        int index = 0;
        for (int i = 0; i < segments / 2; i++)
        {
            float a1 = Mathf.PI * (float)(i + 1) / (segments / 2 + 1);
            float sin1 = Mathf.Sin(a1);
            float cos1 = Mathf.Cos(a1);

            for (int j = 0; j <= segments; j++)
            {
                float a2 = Mathf.PI * 2f * (float)(j == segments ? 0 : j) / segments;
                float sin2 = Mathf.Sin(a2);
                float cos2 = Mathf.Cos(a2);

                vertices[index] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius + center + translation;
                vertices[index] = Vector3.Scale(vertices[index] - center, scale) + center;
                index++;
            }
        }

        for (int i = 0; i < segments / 2 - 1; i++)
        {
            for (int j = 0; j < segments; j++)
            {
                int current = i * (segments + 1) + j;
                int next = current + segments + 1;

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(vertices[current], vertices[current + 1]);
                Gizmos.DrawLine(vertices[current], vertices[next]);
                Gizmos.DrawLine(vertices[next], vertices[current + 1]);

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(vertices[next], vertices[next + 1]);
                Gizmos.DrawLine(vertices[current + 1], vertices[next + 1]);
            }
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(vertices[i], 0.05f);
        }
    }
}
