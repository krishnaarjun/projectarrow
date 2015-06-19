using UnityEngine;
using System.Collections;

public class AttackAI : MonoBehaviour {

	bool inrange;
	public float timer = 0;
	public float fireinterval;
	int i=0;
	Animator anim;
	public GameObject player;
	PlayerHealth playerhealth;
	public int damageamount;
	public NavMeshAgent nav;

	void Awake()
	{
	
		anim = GetComponent <Animator> ();
		playerhealth = player.GetComponent<PlayerHealth> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Start () 
	{
	
	}

	void OnTriggerEnter(Collider obj)
	{
		if (obj.gameObject.tag == "Player") 
		{
			print ("you are in range");
			inrange = true;
		} 

	}

	void Update () 
	{
		timer += Time.deltaTime;
		if (timer > fireinterval && inrange == true && playerhealth.curhealth != 0) 
		{
			attack();		
		}
		else if (playerhealth.curhealth == 0)
		{
			anim.SetTrigger("playerdead");
			nav.enabled = false;
		}
		
	}
	void attack()
	{
		timer = 0;
		anim.SetBool ("att", true);

	}

	void attackevent(float a)
	{
		if (playerhealth.curhealth > 0) 
		{
			playerhealth.takehealth (damageamount);
		}

	}

	void reflex(int g)
	{
		playerhealth.anim.SetTrigger ("reflex");
	}
}
