using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public static WeaponManager instance;

	public Sprite[] Sprites;
	Weapon[] weaponList;
	int weaponCount = 3;

	void Awake()
	{
		instance = GetComponent<WeaponManager> ();
		weaponList = new Weapon[weaponCount];

		weaponList [0] = new Weapon (0, "Hand", 1, 300.0f, Sprites[0]);
		weaponList [1] = new Weapon (1, "Sling Shot", 1, 600.0f, Sprites[1]);
		weaponList [2] = new Weapon (2, "2Hands", 1, 500.0f, Sprites[2]);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Weapon NextWeapon()
	{
		if(PlayerStatus.instance.currentWeapon.id + 1 >= weaponCount)
		{
			return weaponList [0];
		}else
		{
			return weaponList [PlayerStatus.instance.currentWeapon.id + 1];
		}
	}
	public Weapon GetWeapon()
	{
		return weaponList [PlayerStatus.instance.currentWeapon.id];
	}
	public Weapon GetWeapon(int id)
	{

		PlayerStatus.instance.currentWeapon = weaponList [id];
		return weaponList [id];
	}
}
