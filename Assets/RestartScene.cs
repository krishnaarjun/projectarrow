using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour {


	public void Restart()
	{
		StartCoroutine ("Rscene");
	}

	IEnumerator Rscene()
	{
		float Fadetime = GameObject.Find ("FadeLevel").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (2.5f);
		Application.LoadLevel(0);
	}
}
