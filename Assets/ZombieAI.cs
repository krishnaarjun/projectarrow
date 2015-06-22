using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	public Transform Player;

	public NavMeshAgent navmesh;

	EnemyHealth enemyhealth;

	PlayerHealth playerhealth;

	void Awake()
	{

		Player = GameObject.FindGameObjectWithTag ("Player").transform;

		navmesh = GetComponent <NavMeshAgent> ();

		enemyhealth = GetComponent<EnemyHealth> ();

		playerhealth = Player.GetComponent<PlayerHealth> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		int currenthealth = PlayerHealth.curhealth;
		if (enemyhealth.curhealth > 0 && currenthealth > 0) 
		{
			navmesh.SetDestination (Player.position);
		} 
		else 
		{
			navmesh.enabled = false;
		}
	}


}
