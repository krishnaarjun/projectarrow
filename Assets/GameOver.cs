﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	Animator anim;
	public float timer;
	public float restarttime;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerHealth.curhealth <= 0) 
		{
			anim.SetTrigger("GameOver");
			timer +=Time.deltaTime;
			if(timer > restarttime)
			{
				Application.LoadLevel(1);
			}
		}
	}
}
