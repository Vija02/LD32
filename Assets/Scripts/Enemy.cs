using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject DeathParticle;

	public int id;
	public int totalLife;
	public float walkSpeed;
	public float knockBackForce;
	public GameObject theObject;

	GameObject player;
	int currentLife;
	string moveDirection;

	public Enemy(int ID, int TotalLife, float WalkSpeed, GameObject TheObject)
	{
		id = ID;
		totalLife = TotalLife;
		walkSpeed = WalkSpeed;
		theObject = TheObject;
	}
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		currentLife = totalLife;
		moveDirection = "Left";
	}
	
	// Update is called once per frame
	void Update () {
		if (moveDirection == "Right" && id != 3) 
		{
			transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
			transform.position += new Vector3 (walkSpeed*Time.deltaTime, 0.0f, 0.0f);
		}
		if (moveDirection == "Left" && id != 3) 
		{
			transform.localScale = new Vector3(1.0f,1.0f,1.0f);
			transform.position -= new Vector3 (walkSpeed*Time.deltaTime, 0.0f, 0.0f);
		}

		if (id == 3) 
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.position.x-transform.position.x, player.transform.position.y-transform.position.y).normalized*walkSpeed);
		}


		if(currentLife <= 0)
		{
			PlayerStatus.instance.AddCoin(totalLife*2);
			Instantiate(DeathParticle, transform.position,Quaternion.Euler(-90.0f,0.0f,0.0f));
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Slime"))
		{
			moveDirection = moveDirection == "Left"?"Right":"Left";
		}
		if(collision.transform.CompareTag("Bullet"))
		{
			Vector3 ForceDirection = (collision.transform.position-transform.position).normalized;
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceDirection.x*knockBackForce/4, ForceDirection.y*knockBackForce/4+200.0f));
			currentLife--;
		}
		if(collision.transform.CompareTag("Player"))
		{
			PlayerStatus.instance.UseCoin(totalLife);
			GetComponent<AudioSource>().Play();

			Vector3 ForceDirection = (collision.transform.position-transform.position).normalized;
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceDirection.x*knockBackForce, ForceDirection.y*knockBackForce+200.0f));

			Instantiate(DeathParticle, collision.transform.position,Quaternion.Euler(-90.0f,0.0f,0.0f));//Player hurt particle
		}
	}
	void OnTriggerEnter2D(Collider2D collider)//pathing
	{
		if (collider.transform.CompareTag ("AI_Right")) 
		{
			moveDirection = "Right";
		}
		if (collider.transform.CompareTag ("AI_Left")) 
		{
			moveDirection = "Left";
		}
	}
}
