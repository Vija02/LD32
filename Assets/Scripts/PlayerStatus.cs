using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public static PlayerStatus instance;
	public int currentCoins = 10;
	public Weapon currentWeapon;

	void Awake()
	{
		instance = gameObject.GetComponent<PlayerStatus> ();
	}
	// Use this for initialization
	void Start () {
		ChangeWeapon (0);
		UIManager.instance.UpdateCoins (currentCoins);
	}
	
	// Update is called once per frame
	void Update () {
		if(currentCoins <= 0)
		{
			//LOSE
			PlayerController.instance.enabled = false;
			UIManager.instance.ShowDeathScreen();
		}
	}
	public void UseCoin(int coinCount)
	{
		currentCoins -= coinCount;
		UIManager.instance.UpdateCoins (currentCoins);
	}
	public void AddCoin(int coinCount)
	{
		currentCoins += coinCount;
		UIManager.instance.UpdateCoins (currentCoins);
	}
	public void ChangeWeapon()
	{
		currentWeapon = WeaponManager.instance.NextWeapon ();
		PlayerController.instance.bulletSpeed = currentWeapon.bulletForce;
		PlayerController.instance.bulletCount = currentWeapon.bulletPerShot;
		UIManager.instance.UpdateWeaponSlot (currentWeapon.theSprite);
	}
	public void ChangeWeapon(int id)
	{
		currentWeapon = WeaponManager.instance.GetWeapon(id);
		PlayerController.instance.bulletSpeed = currentWeapon.bulletForce;
		PlayerController.instance.bulletCount = currentWeapon.bulletPerShot;
		UIManager.instance.UpdateWeaponSlot (currentWeapon.theSprite);
		
	}
}
