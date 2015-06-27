using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreMananger : MonoBehaviour {

	public Text scoretext;

	void Awake()
	{
		scoretext.text = "" + PlayerPrefs.GetInt ("HighScore");
	}
}
