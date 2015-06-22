using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxhealth = 100;
	public int curhealth = 100;
	Animator anim;
	bool isdead = false;
	ZombieAI zombieai;
	bool destroy = false;
	Rigidbody rigid;
	public float dspeed;
	CapsuleCollider cap;
	public int myscoreval = 50;
	public float timer;

	void Awake()
	{
		anim = GetComponent <Animator> ();
		zombieai = GetComponent<ZombieAI> ();
		rigid = GetComponent<Rigidbody> ();
		cap = GetComponent<CapsuleCollider> ();
	}

	void Start () 
	{
		curhealth = maxhealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		destroyit ();
	}
	void destroyit()
	{	
		if (destroy) 
		{
			transform.Translate(-Vector3.up * dspeed * Time.deltaTime);
		}
	}

	public void TakeHealth(int amount,bool arrow)
	{	
		if (arrow && timer >= 1) 
		{
			curhealth -= amount;
			timer = 0;
		} 
		else 
		{
			if(timer >1)
			{
				curhealth -= amount;
				timer=0;
			}
		}

		if (curhealth <= 0 & !isdead)
		{
			anim.SetTrigger("Dead");
			Death();
		}
	}

	void Death()
	{	
		isdead = true;

		zombieai.navmesh.enabled = false;  

		Manager_Score.curscore += myscoreval;
	}

	void destroyevent(int q)
	{
		cap.enabled = false;
		
		rigid.isKinematic = true;

		destroy = true;

		Destroy (gameObject, 3f);
	}
}
