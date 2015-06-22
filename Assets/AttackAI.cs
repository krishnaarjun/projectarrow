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
		player = GameObject.FindGameObjectWithTag ("Player");
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
		int chealth = PlayerHealth.curhealth;
		timer += Time.deltaTime;
		if (timer > fireinterval && inrange == true && PlayerHealth.curhealth != 0) 
		{
			attack();		
		}
		else if (chealth <= 0)
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
		int cuhealth = PlayerHealth.curhealth;
		if (cuhealth > 0) 
		{
			playerhealth.takehealth (damageamount);
		}

	}

	void reflex(int g)
	{
		playerhealth.anim.SetTrigger ("reflex");
	}
}
