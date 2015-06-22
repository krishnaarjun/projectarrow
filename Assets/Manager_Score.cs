using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager_Score : MonoBehaviour {

	public static int curscore;
	Text thetext;

	void Awake()
	{
		thetext = GetComponent<Text> ();
		curscore = 0;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		thetext.text = "SCORE : " + curscore;
	}
}
