using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitUI : MonoBehaviour {

	GameObject ExitText;

	void Awake()
	{
		ExitText = GameObject.Find ("ExitText");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.transform.CompareTag("Player"))
		{
			ExitText.GetComponent<Text>().text = "Press S to enter";
		}
	}
	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.transform.CompareTag("Player") && Input.GetKeyDown("s"))
		{
			UIManager.instance.ChangeScene("SurvivalScene");
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.transform.CompareTag("Player"))
		{
			ExitText.GetComponent<Text>().text = "";
		}
	}
}
