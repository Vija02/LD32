using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour {

	GameObject HelpText;
	public string text;

	void Awake()
	{
		HelpText = GameObject.Find ("HelpText");
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
			HelpText.GetComponent<Text>().text = text;
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.transform.CompareTag("Player"))
		{
			HelpText.GetComponent<Text>().text = "";
		}
	}
}
