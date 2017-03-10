using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject slimeObject;
	GameObject slime;
	bool spawn = true;

	// Use this for initialization
	void Start () {
		slime = (GameObject)Instantiate(slimeObject, transform.position, Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(slime == null && spawn )
		{
			StartCoroutine(SpawnEnemy());
			spawn = false;
		}
	}
	IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds(3.0f);
		slime = (GameObject)Instantiate(slimeObject, transform.position, Quaternion.identity);
		spawn = true;
	}
}
