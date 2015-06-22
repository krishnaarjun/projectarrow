using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Restartlevel : MonoBehaviour {



	void Start()
	{

	}

	public void RestartScene()
	{
		print ("restarting");
		Application.LoadLevel (0);
	}
}
