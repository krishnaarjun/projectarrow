using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public float force;
	public Rigidbody rigid;
	float time;
	public float lifetime;
	public bool forceenabled;
	public int damageamount;
	RaycastHit enemyhit;
	Ray enemyray;


	void Awake()
	{

	
	}
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		if (forceenabled)
		{
			rigid.AddForce (transform.forward * force);
		}
		else
		{
			transform.position += force * transform.forward;
		
		}
		if (time > lifetime) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{


			enemyray.origin = transform.position;
			enemyray.direction = transform.forward;

			if(Physics.Raycast(enemyray,out enemyhit))
			{
				print ("hit enemy");
				EnemyHealth enemyhealth = enemyhit.collider.GetComponent<EnemyHealth>();
				if(enemyhealth != null)
				{
					print("calling takehealth func");
					enemyhealth.TakeHealth(damageamount,true);
				}
				Destroy(gameObject);
			}


		}
	
	}
}
