using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	public void load()
	{
		StartCoroutine ("loadgame");
	}

	IEnumerator loadgame()
	{
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel ("Main");
	}
}
