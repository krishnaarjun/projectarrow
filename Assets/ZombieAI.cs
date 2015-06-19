using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	public Transform Player;

	public NavMeshAgent navmesh;


	void Awaker()
	{

		//Player = GameObject.FindGameObjectWithTag ("player").transform;

		navmesh = GetComponent <NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		navmesh.SetDestination (Player.position);

	}


}
