using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

	float lifeTime = 0;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime++;
		if(lifeTime >= 200)
		{
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			PlayerStatus.instance.AddCoin(1);
			Destroy(gameObject);
		}
	}
}
