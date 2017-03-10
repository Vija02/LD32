using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public GameObject DeathParticle;
	public GameObject JumpSound;
	
	public float playerSpeed;
	public float jumpForce;
	public float bulletSpeed;
	public int bulletCount;
	public GameObject CoinBullet;

	public float cameraBorderLeft;
	public float cameraBorderRight;
	public float cameraBorderUp;

	bool takeCoinPerSec = false;

	void Awake()
	{
		instance = GetComponent<PlayerController>();
		JumpSound = GameObject.Find ("JumpSound");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xLoc;
		xLoc = transform.position.x;
		xLoc = transform.position.x < cameraBorderLeft ? cameraBorderLeft:xLoc;
		xLoc = transform.position.x > cameraBorderRight ? cameraBorderRight:xLoc;

		float yLoc;
		yLoc = transform.position.y;
		yLoc = transform.position.y > cameraBorderUp ? cameraBorderUp:yLoc;

		Camera.main.transform.position = new Vector3 (xLoc, yLoc, -10);
		GetComponent<Animator>().SetBool("isWalking",false);
		//Movement
		if(Input.GetKey("d") && Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x) <= 1.5f && !Physics2D.Raycast(new Vector2(transform.position.x + 0.34f, transform.position.y),new Vector2(1.0f,0.0f), 0.1f))
		{
			gameObject.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
			if(GetComponent<AudioSource>().isPlaying == false && Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-0.5f),new Vector2(0.0f,-1.0f), 0.1f))
			{
				GetComponent<AudioSource>().Play();
			}
			gameObject.transform.position += new Vector3(playerSpeed*Time.deltaTime,0.0f,0.0f);
			GetComponent<Animator>().SetBool("isWalking", true);
		}
		if(Input.GetKey("a") && Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x) <= 1.5f && !Physics2D.Raycast(new Vector2(transform.position.x - 0.34f, transform.position.y),new Vector2(-1.0f,0.0f), 0.1f))
		{
			gameObject.transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
			if(GetComponent<AudioSource>().isPlaying == false && Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-0.5f),new Vector2(0.0f,-1.0f), 0.1f))
			{
				GetComponent<AudioSource>().Play();
			}
			gameObject.transform.position -= new Vector3(playerSpeed*Time.deltaTime,0.0f,0.0f);
			GetComponent<Animator>().SetBool("isWalking", true);
		}
		if(Input.GetKeyDown("w"))
		{
			if(Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-0.5f),new Vector2(0.0f,-1.0f), 0.1f))
			{
				JumpSound.GetComponent<AudioSource> ().Play ();
				gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,jumpForce));
			}
		}
		if(Input.GetKey("space"))
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,jumpForce/30));
			Instantiate(DeathParticle, transform.position,Quaternion.Euler(-270.0f,0.0f,0.0f));
		}
		if(Input.GetKeyDown("space"))
		{
			StartCoroutine(UseCoinPerSec(0.1f));
			takeCoinPerSec = true;
		}
		if(Input.GetKeyUp("space"))
		{
			takeCoinPerSec = false;
		}
		//endofmovement----------------------------------------------------------------------
		//weapon
		if(Input.GetKey("1"))
		{
			PlayerStatus.instance.ChangeWeapon(0);
		}else if(Input.GetKey("2"))
		{
			PlayerStatus.instance.ChangeWeapon(1);
		}else if(Input.GetKey("3"))
		{
			PlayerStatus.instance.ChangeWeapon(2);
		}
		//endofweapon
		//Shooting
		if(Input.GetMouseButtonDown(0) && PlayerStatus.instance.currentWeapon.id != 2)
		{
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity) && hit.transform.CompareTag("ShootScreen"))
			{
				Vector3 clamppedDir = (hit.point - transform.position).normalized;

				for(var i=0; i<bulletCount ;i++)
				{
					GameObject bullet = (GameObject)Instantiate(CoinBullet, transform.position+ReturnNormalized(clamppedDir, 0.44f, 0.56f), Quaternion.identity);
					bullet.GetComponent<Rigidbody2D>().AddForce(clamppedDir*bulletSpeed);
				}

				PlayerStatus.instance.UseCoin(bulletCount);
			}
		}
		if(Input.GetMouseButton(0) && PlayerStatus.instance.currentWeapon.id == 2)
		{
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity) && hit.transform.CompareTag("ShootScreen"))
			{
				Vector3 clamppedDir = (hit.point - transform.position).normalized;

				GameObject bullet = (GameObject)Instantiate(CoinBullet, transform.position+ReturnNormalized(clamppedDir, 0.44f, 0.56f), Quaternion.identity);
				bullet.GetComponent<Rigidbody2D>().AddForce(clamppedDir*bulletSpeed);
				//push up
				if(ReturnNormalized(clamppedDir, 0.44f, 0.56f).y == -0.56f)
				{
					GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,100.0f));
				}

				PlayerStatus.instance.UseCoin(bulletCount);
			}
		}
	}

	public static Vector3 ReturnNormalized(Vector3 direction, float clampX, float clampY)
	{
		if (Mathf.Abs (direction.x) >= Mathf.Abs (direction.y)) {
			float persen = (Mathf.Abs (direction.x) - clampX) * 100 / Mathf.Abs (direction.x);
			float heightVector = ((100 - persen) / 100) * direction.y;
			Vector3 newDirection = new Vector3 (((100 - persen) / 100) * direction.x, heightVector, 0.0f);
			return newDirection;
		} else if (Mathf.Abs (direction.x) <= Mathf.Abs (direction.y)) {
			float persen = (Mathf.Abs (direction.y) - clampY) * 100 / Mathf.Abs (direction.y);
			float heightVector = ((100 - persen) / 100) * direction.x;
			Vector3 newDirection = new Vector3 (heightVector, ((100 - persen) / 100) * direction.y, 0.0f);
			return newDirection;
		} else {
			return Vector3.zero;
		}
	}

	IEnumerator UseCoinPerSec(float seconds)
	{
		PlayerStatus.instance.UseCoin (1);
		yield return new WaitForSeconds(seconds);
		if(takeCoinPerSec)
		{
			StartCoroutine(UseCoinPerSec(seconds));
		}
	}
}
