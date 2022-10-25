using UnityEngine;

public class FieldOfView : MonoBehaviour
{
	public float viewDistance = 50.0f;
	public float fov = 90.0f;
	int rayCount = 50;

	private Mesh mesh;

	private void Start()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
	}

	private void Update()
    {
		Vector3 origin = Vector3.zero;
		float angle = 0.0f;
		float angleIncrease = fov / rayCount;
		
		Vector3[] vertices = new Vector3[rayCount + 1 + 1];
		Vector2[] uv = new Vector2[vertices.Length];
		int[] triangles = new int[rayCount * 3];

		vertices[0] = origin;

		int vertexIndex = 1;
		int triangleIndex = 0;
		for (int i = 0; i <= rayCount; i++)
		{
			Vector3 vertex;
			RaycastHit2D hit = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);
			if (hit.collider == null || hit.collider.transform.name == "Player")
			{
				vertex = origin + GetVectorFromAngle(angle) * viewDistance;
			}
			else
			{
				vertex = hit.point;
			}

			vertices[vertexIndex] = vertex;

			if (i > 0)
			{
				triangles[triangleIndex + 0] = 0;
				triangles[triangleIndex + 1] = vertexIndex - 1;
				triangles[triangleIndex + 2] = vertexIndex;

				triangleIndex += 3;
			}

			vertexIndex++;
			angle -= angleIncrease;
		}

		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
	}

	private Vector3 GetVectorFromAngle(float angle)
	{
		float angleRad = angle * (Mathf.PI / 180.0f);
		return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
	}
}
