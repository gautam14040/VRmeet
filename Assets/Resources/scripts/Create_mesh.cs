using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System ;
using Leap;
using Leap.Unity;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Create_mesh : MonoBehaviour {

	public HandModel hand ;
//	private LeapHandController handController;
	public List<Vector3> newVertices = new List<Vector3>() ;
	private List<Vector2> newUV =  new List<Vector2>()  ;
	public List<int> newTriangles =  new List<int>()  ;

	void Start () {
		//Lhand = GetComponent<LeapHandController>();
		//Mesh Initialize
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = newVertices.ToArray();	
		mesh.uv = newUV.ToArray();
		mesh.triangles = newTriangles.ToArray();
	}	
	
	void Update () {
		if(hand != null){
			Mesh mesh = GetComponent<MeshFilter>().mesh;
			mesh.Clear();
			int tri = newVertices.Count;
			if (hand != null) {
				newVertices.Add (hand.fingers [0].GetTipPosition ());
				newVertices.Add (hand.fingers [1].GetTipPosition ());
				newVertices.Add (hand.fingers [4].GetTipPosition ());
			}

			newTriangles.Add (tri);
			newTriangles.Add (tri+1);
			newTriangles.Add (tri+2);

			newTriangles.Add (tri);
			newTriangles.Add (tri+2);
			newTriangles.Add (tri+1);

			//Update Mesh
			mesh.vertices = newVertices.ToArray();
			mesh.uv = newUV.ToArray();
			mesh.triangles = newTriangles.ToArray();
		}
	}


	private void OnDrawGizmos () {
		Gizmos.color = Color.black;
		if (newVertices == null) {
			return;
		}
		foreach (Vector3 v in newVertices) {
			Gizmos.DrawSphere(v , 0.001f);
		}
			
	}

//-------------------------------END OF CLASS -----------------
}
