using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public float force;
	public Rigidbody rigid;
	float time;
	public float lifetime;
	public bool forceenabled;
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

	/*void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			print ("hit enemy");
			Destroy(gameObject);

		}
	
	}*/
}
