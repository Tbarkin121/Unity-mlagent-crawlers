using UnityEngine;
using System.Collections;

public class TriBodyMesh : MonoBehaviour {


    public int numPts = 3;
    public float height = 0.5f;
    public float radius = 3f;
	// Use this for initialization
	void Start () {

		MeshFilter mf = GetComponent<MeshFilter>();
        MeshCollider mc = GetComponent<MeshCollider>();
		Mesh mesh = mf.mesh;
        
        

		//Vertices//
        float thetaStep =  Mathf.Deg2Rad * 360.0f/numPts;
		Vector3[] vertices = new Vector3[]
		{
			new Vector3(radius*Mathf.Cos(0*thetaStep), -height, radius*Mathf.Sin(0*thetaStep)),
            new Vector3(radius*Mathf.Cos(0*thetaStep), height, radius*Mathf.Sin(0*thetaStep)),

            new Vector3(radius*Mathf.Cos(1*thetaStep), -height, radius*Mathf.Sin(1*thetaStep)),
            new Vector3(radius*Mathf.Cos(1*thetaStep), height, radius*Mathf.Sin(1*thetaStep)),

            new Vector3(radius*Mathf.Cos(2*thetaStep), -height, radius*Mathf.Sin(2*thetaStep)),
            new Vector3(radius*Mathf.Cos(2*thetaStep), height, radius*Mathf.Sin(2*thetaStep))

		};

		//Triangles// 3 points, clockwise determines which side is visible
		int[] triangles = new int[]
		{
			//left face//
			1,3,0,//first triangle
			3,2,0,//second triangle

			//back face//
			3,4,2,//first triangle
			3,5,4,//second triangle

			//right face//
			5,1,0,//first triangle
			5,0,4,//second triangle

			//top face//
			5,3,1,

			//bottom face//
			0,2,4

		};
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		;
		mesh.RecalculateNormals();
        mc.sharedMesh = mesh;
	
	}

    
}