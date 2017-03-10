using UnityEngine;
using System.Collections;

public class Weapon {

	public int id;
	public string name;
	public int bulletPerShot;
	public float bulletForce;
	public Sprite theSprite;

	public Weapon(int Id, string Name, int BulletPerShot, float BulletForce, Sprite TheSprite)
	{
		id = Id;
		name = Name;
		bulletPerShot = BulletPerShot;
		bulletForce = BulletForce;
		theSprite = TheSprite;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
