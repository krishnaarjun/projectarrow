using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour {

	//EnemyHealth enemyhealth;
	public float radius;
	public int meleedamage;
	int damagecounter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	//Detect (transform.position, 1);
	}
	void meleeattack(float c)
	{
		print ("melee");
		Detect (transform.position, radius);
	}

	void Detect(Vector3 pos,float rad)
	{
		Collider[] hits = Physics.OverlapSphere (pos, rad);

		for (int i=0; i <hits.Length; i++) 
		{
			if(hits[i].gameObject.tag == "Enemy")
			{	
				print (hits[i].gameObject.tag);
				EnemyHealth enemyhealth = hits[i].GetComponent<EnemyHealth>();
				enemyhealth.TakeHealth(meleedamage,false);
				damagecounter = 1;
			}
		}
	}
}
