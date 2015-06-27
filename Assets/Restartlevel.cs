using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Restartlevel : MonoBehaviour {



	void Start()
	{

	}

	IEnumerator RestartScene()
	{
		print ("restarting");
		float Fadetime = GameObject.Find ("FadeLevel").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (Fadetime);
		Application.LoadLevel (0);
	}
}
