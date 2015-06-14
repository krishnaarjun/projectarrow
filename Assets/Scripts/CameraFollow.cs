using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;            
	public float smoothing = 5f;
	Vector3 offset;
	// Use this for initialization
	void Start ()
	{
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetCamPos = target.position + offset;
		
		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
