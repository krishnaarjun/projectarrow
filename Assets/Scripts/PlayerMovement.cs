﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameObject arrow;
	public Transform muzzlepoint = null;
	public float waittime = 2.5f;
	protected bool iswaiting = false;
	public bool button;
	public GameObject player;
	Collider collider;
	public float rotspeed = 6f;
	public float speed = 6f;    
	public int meleeamount;
	Vector3 movement;  
	Animator anim;
	Rigidbody playerRigidbody;          
	int floorMask;                      
	float camRayLength = 1000f;    
	Ray camRay;
	bool aim;
	GameObject enemy;
	int i=1;
	bool inrange;

	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();

	}

	void Start()
	{
		TouchInputManager.PassInputToLayout (LayoutID.Main, true);
		TouchInputManager.RenderLayout (LayoutID.Main, true);

	}
	
	void Update()
	{
		readjoy ();
		getinput ();
	
		//print("you have meleed"+i+"Zombies");
	}

	/*void OnTriggerEnter(Collider coll)
	{	
		if (coll.gameObject.tag == "Enemy")
		{	
			inrange = true;
			print ("enemy entered");
			GameObject enemyobj = coll.gameObject;
			enemy = enemyobj;

		}
		i++;
	}*/

	void OnTriggerExit(Collider co)
	{
		inrange = false;
	}

	void readjoy()
	{
		Vector2 joystick = TouchInputManager.GetJoystick (InputID.Rotate, LayoutID.Main);

		float angle = Mathf.Atan2 (joystick.x , joystick.y ) * Mathf.Rad2Deg;

		if (angle != 0)
			turn (angle);
	
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);
		
		movement = movement.normalized * speed * Time.deltaTime;
		
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void turn(float angl)
	{
		transform.eulerAngles = new Vector3 (0, angl, 0);
	}
	void Turning ()
	{	

		if (Input.touchCount > 0) {

			camRay = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			//print(Input.GetTouch(i).position);

			RaycastHit floorHit;

			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;


				Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
				//playerRigidbody.MoveRotation (newRotation);
				playerRigidbody.transform.rotation = Quaternion.Lerp (transform.rotation, newRotation, rotspeed);
				
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
			if (TouchInputManager.GetButton (InputID.Melee,LayoutID.Main))
			{
				AnimateMelee(true);
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
			//print (aim);


	}

	void AnimateMelee(bool value)
	{
		anim.SetBool ("melee", value);
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
		//print ("event executed");
	}

	void reset(float b)
	{
		anim.SetBool ("melee", false);
	}

	/*void meleeattack(float c) 
	{	
		if (inrange)
		{
			EnemyHealth enemyhealth = enemy.GetComponent<EnemyHealth> ();
			if (enemyhealth != null) 
			{

				if (enemyhealth.curhealth > 0)
				{
						enemyhealth.TakeHealth (meleeamount);
				}
			}
		}


	}*/




void lookat()
	{
		int tapCount = Input.touchCount;
		if(tapCount > 0)
		{
			print ("calling");
			Vector3 touch = Input.GetTouch(0).position;
			Vector3 screen = Camera.main.ScreenToWorldPoint(touch);//new Vector3(touch.x, touch.y, Camera.main.nearClipPlane + 5.0f));
			Vector3 lookPos = screen - player.transform.position;
			lookPos.y = 0;
			var rot = Quaternion.LookRotation(lookPos); // now get the desired rotation
			player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rot, rotspeed * Time.deltaTime);
		}
	}
	


}

