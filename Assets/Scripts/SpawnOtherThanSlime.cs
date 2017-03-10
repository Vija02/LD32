using UnityEngine;
using System.Collections;

public class SpawnOtherThanSlime : MonoBehaviour {

	public static int activeTurn;

	public int monsterToSpawn;
	public bool active = false;
	public bool spawn;
	GameObject monster;

	// Use this for initialization
	void Start () {
		spawn = true;
		if(active)
		{
			monster = (GameObject)Instantiate(EnemyManager.instance.enemyList[monsterToSpawn].theObject, transform.position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (activeTurn == monsterToSpawn) 
		{
			active = true;
		}
		if(monster == null && spawn && active)
		{
			StartCoroutine(SpawnEnemy());
			spawn = false;
		}
	}
	IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds(3.0f);
		monster = (GameObject)Instantiate(EnemyManager.instance.enemyList[monsterToSpawn].theObject, transform.position, Quaternion.identity);
		spawn = true;
	}
}
