using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUITexture))]

public class FloatBar : MonoBehaviour 
{
	public Transform target;
	public Vector3 offset = Vector3.up;
	public bool conscreen = false;
	public float cborder = 0.05f;
	private Camera cam;
	private Transform mytransform;
	private Transform camtransform;
	// Use this for initialization

	void Start () 
	{
		mytransform = transform;
		cam = Camera.main;
		camtransform = cam.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (conscreen) {
			Vector3 relative = camtransform.InverseTransformPoint (target.position);
			relative.z = Mathf.Max (relative.z, 1.0f);
			mytransform.position = cam.WorldToViewportPoint (camtransform.TransformPoint (relative + offset));

			float x = Mathf.Clamp(mytransform.position.x, cborder, 1.0f - cborder);
			float y = Mathf.Clamp(mytransform.position.y, cborder, 1.0f - cborder);
			float z = mytransform.position.z;
			mytransform.position = new Vector3 (x,y,z);
		} else {
			mytransform.position = cam.WorldToViewportPoint (target.position + offset);
		}
	}
}

