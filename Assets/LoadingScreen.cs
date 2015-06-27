using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public string levelname;
	AsyncOperation async;


	public void startload()
	{
		StartCoroutine ("loadnow");
	}

	public void startscene()
	{
		async.allowSceneActivation = true;
	}

	IEnumerator loadnow()
	{
		print ("calling");
		async = Application.LoadLevelAsync(levelname);
		async.allowSceneActivation = false;

		while (!async.isDone)
		{
			float progress = async.progress;
			if(progress >= 0.9f)
			{
				break;
			}
			yield return null;
		}

		async.allowSceneActivation = true;
		yield return async;
	}


}
