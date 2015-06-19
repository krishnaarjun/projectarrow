using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxhealth = 100;
	public int curhealth = 100;
	bool isdead;
	public Slider healthbar;
	public Animator anim;
	public Image flashimg;
	public Image fadeimg;
	PlayerMovement playermovement;
	public float fspeed;
	public Text ht;
	public Color flashcolor = new Color(1f,0f,0f,0.1f);
	public Color fadecolor = new Color (0f, 0f, 0f, 0.1f);
	public Text gameover;
	ZombieAI zombieai;
	public GameObject zombie;
	bool flash;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		playermovement = GetComponent<PlayerMovement> ();
		zombieai = zombie.GetComponent<ZombieAI> ();

	}
	// Use this for initialization
	void Start ()
	{
		curhealth = maxhealth;
		gameover.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		flashscreen ();
	}

	void flashscreen()
	{
		if (flash) {
			flashimg.color = flashcolor;
		} 
		else 
		{
			flashimg.color = Color.Lerp(flashimg.color,Color.clear ,fspeed * Time.deltaTime);
		}
		flash = false;
	
	}

	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Enemy") 
		{
			print ("hit");
		}
	}

	public void takehealth(int amount)
	{	
		flash = true;

		curhealth -= amount;

		healthbar.value = curhealth;

		if (curhealth == 0 && !isdead) 
		{
			death();
		}
	}

	void death()
	{

		isdead = true;

		anim.SetTrigger ("Die");

		TouchInputManager.RenderLayout (LayoutID.Main, false);

		fadeimg.color = Color.clear;
		
		fadeimg.color = Color.Lerp(fadeimg.color,fadecolor,50 * Time.deltaTime);

		healthbar.enabled = false;

		ht.enabled = false;

		gameover.enabled = true;

		gameover.CrossFadeColor (new Color (255f, 255f, 255f), 10f * Time.deltaTime, true, false);

		playermovement.enabled = false;

		zombieai.enabled = false;


	}
}
