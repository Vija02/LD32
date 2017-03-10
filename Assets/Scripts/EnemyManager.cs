using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public static EnemyManager instance;

	public GameObject[] theObjectList;

	public Enemy[] enemyList;

	void Awake()
	{
		instance = GetComponent<EnemyManager> ();

		enemyList = new Enemy[4];
		
		enemyList [0] = new Enemy (0, 1, 0.5f, theObjectList[0]);//green
		enemyList [1] = new Enemy (1, 2, 1.0f, theObjectList[1]);//purple
		enemyList [2] = new Enemy (2, 3, 1.5f, theObjectList[2]);//red
		enemyList [3] = new Enemy (3, 6, 4.0f, theObjectList [3]);//evilcoin
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
