using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	public GameObject texture;
	public float fadeSpeed;

	bool fadeActive = false;
	float fadeTowards;
	GameObject GameManager;

	void Awake()
	{
		fadeSpeed = 1.5f;
		GameManager = GameObject.Find("GameManager");
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(fadeActive &&  fadeTowards == 1 && texture.GetComponent<CanvasGroup>().alpha <= 1)
		{
			float alpha = Mathf.Clamp01(fadeSpeed*Time.deltaTime);
			GameManager.GetComponent<AudioSource>().volume -= alpha;
			texture.GetComponent<CanvasGroup>().alpha += alpha;
		}
		if(fadeActive &&  fadeTowards == 0 && texture.GetComponent<CanvasGroup>().alpha >= 0)
		{
			float alpha = Mathf.Clamp01(fadeSpeed*Time.deltaTime);
			texture.GetComponent<CanvasGroup>().alpha -= alpha;
		}
	}
	public float fadeTo(float fadeDirection)
	{
		if(fadeDirection == 1)
		{
			fadeTowards = 1;
			fadeActive = true;

			//Color color = texture.GetComponent<Image>().color; 
			//texture.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 255);
			//texture.SetActive(true);
		}
		return fadeSpeed;
	}
	void OnLevelWasLoaded()
	{
		texture.GetComponent<CanvasGroup>().alpha = 1;
		fadeTowards = 0;
		fadeActive = true;
	}
}
