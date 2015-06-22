using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public PlayerHealth playerhealth;
	public GameObject[] enemy;
	public float spawninterval = 3f;
	public Transform[] spawnlocations;
	public int Difficulty =1;
	public GameObject player;
	float timer;
	void Awake()
	{
		playerhealth = player.GetComponent<PlayerHealth> ();
	
	}
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnAI", spawninterval, spawninterval);
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		SetDiff ();

	}

	void SpawnAI()
	{	
		int currhealth = PlayerHealth.curhealth;
		if(currhealth <=0)
		{
			return;
		}
		int spawnpointindex = Random.Range(0,spawnlocations.Length);

		int spawnenindex = Random.Range(0,enemy.Length);

		Instantiate(enemy[spawnenindex],spawnlocations[spawnpointindex].position,spawnlocations[spawnpointindex].rotation);
	}

	void SetDiff()
	{
		if (timer > 30) 
		{
			Difficulty++;
			timer=0;
		}

	}
}
