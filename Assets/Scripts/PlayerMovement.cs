﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Transform arrow;
	public Transform muzzlepoint = null;
	public float waittime = 2.5f;
	protected bool iswaiting = false;
	public bool button;


	public float rotspeed = 6f;
	public float speed = 6f;    
	Vector3 movement;  
	Animator anim;
	Rigidbody playerRigidbody;          
	int floorMask;                      
	float camRayLength = 1000f;    
	Ray camRay;
	bool aim;


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(camRay.origin,camRay.direction * 10);

	}
	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();

	}

	void Start()
	{
		TouchInputManager.PassInputToLayout (LayoutID.Main, true);
		//TouchInputManager.RenderLayout (LayoutID.Main, true);

	}
	
	
	void FixedUpdate ()
	{
	
		Turning ();


	}

	void Update()
	{

		getinput ();


	}
	
	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);
		
		movement = movement.normalized * speed * Time.deltaTime;
		
		playerRigidbody.MovePosition (transform.position + movement);
	}
	
	void Turning ()
	{	

		if(Input.touchCount>0)
		{

				camRay = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
				//print(Input.GetTouch(i).position);

				RaycastHit floorHit;

			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
				{
				Vector3 playerToMouse = floorHit.point - transform.position;

				//playerToMouse.y = 0f;

				Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

				//playerRigidbody.MoveRotation (newRotation);
				 playerRigidbody.transform.rotation = Quaternion.Lerp ( transform.rotation , newRotation , rotspeed );

			}
			}
		}
		
	


	void getinput()
	{	
		if (button) 
		{

			if (TouchInputManager.GetButton (InputID.Fire, LayoutID.Main)) 
			{
				Animating (true);
			}
			if (TouchInputManager.GetButtonUp (InputID.Fire, LayoutID.Main)) 
			{
				//Animating (false);
			}
		} 
		else
		{

			int ntouches = Input.touchCount;
		
			if (ntouches > 0) {
				for (int i=0; i<ntouches; i++) {
					Touch touch = Input.GetTouch (i);
				
					if (touch.phase == TouchPhase.Began) {    

						Animating (true);
						print ("You have touched and its stationary");
					} else if (touch.phase == TouchPhase.Ended) {

						Animating (false);
						print ("your touchhas ended");
					}
				}
			
			
			
			
			}
		}
	
	}
	void Animating (bool value)
	{

			aim = value;
			anim.SetBool ("IsAiming", aim);
			print (aim);


	}
	void fire(int i)
	{
		Vector3 position = muzzlepoint.position;
		
		Quaternion rotation = muzzlepoint.rotation;
		
		GameObject newarrow;
		
		newarrow = Instantiate (arrow, position, rotation) as GameObject;
		

		
		
	}
	

	void exec(float a)
	{
		
		
		aim = false;

		anim.SetBool("IsAiming", aim);
		print ("event executed");
	}


		/*if(Input.touches.Length <=0)
		{
		}
		else
		{
			for(int i = 0;i < Input.touchCount;i++)
			{
			
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
						RaycastHit hit = new RaycastHit();
						aim = Physics.Raycast (ray, out hit);
						print(aim);
						//aim = true;
						anim.SetBool ("IsAiming", aim);
						
						
						
						

					}

				if((Input.GetTouch(i).phase == TouchPhase.Ended))
				{
					aim = false;
					anim.SetBool ("IsAiming", aim);
					print(aim);
				}

			}
		}*/
					
	
	


}
