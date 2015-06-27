using UnityEngine;
using System.Collections;

public class ResolutionScaler : MonoBehaviour {

	float baseAspect = 16f / 9f;

	// Use this for initialization
	void Start () 
	{
		Vector2 curaspect = AspectRatio.GetAspectRatio (Screen.width, Screen.height, true);
		baseAspect = curaspect.x / curaspect.y;
	

		float currAspect = 1.0f * Screen.width / Screen.height;
		//Debug.Log(Camera.main.projectionMatrix);
		//Debug.Log(baseAspect + ", " + currAspect + ", " + baseAspect / currAspect);
		Camera.main.projectionMatrix = Matrix4x4.Scale(new Vector3(currAspect / baseAspect, 1.0f, 1.0f)) * Camera.main.projectionMatrix;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
