using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	public GameObject HelpUI;
	public GameObject WeaponSlot;
	public GameObject CoinSlot;
	public GameObject Coins;
	public GameObject DeathScreen;

	void Awake()
	{
		instance = gameObject.GetComponent<UIManager> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void UpdateCoins(int currentCoins)
	{
		Coins.GetComponent<Text> ().text = currentCoins.ToString();
	}
	public void UpdateWeaponSlot(Sprite theSprite)
	{
		WeaponSlot.GetComponent<Image> ().sprite = theSprite;
	}
	public void ChangeScene(string levelName)
	{
		float timeToLoad = GetComponent<Fade> ().fadeTo (1);
		StartCoroutine (LoadSceneAfter(timeToLoad, levelName));
		//Application.LoadLevel (levelName);
	}
	IEnumerator LoadSceneAfter(float seconds, string levelName)
	{
		yield return new WaitForSeconds (seconds);
		Application.LoadLevel (levelName);
	}
	public void ShowDeathScreen()
	{
		DeathScreen.GetComponent<RectTransform> ().localPosition = new Vector3 (0.0f,0.0f,0.0f);
	}
	public void QuitGame()
	{
		Application.Quit ();
	}
}
