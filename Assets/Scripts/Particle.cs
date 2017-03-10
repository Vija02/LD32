using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	public float lifeTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (killSelf ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator killSelf()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy (gameObject);
	}

}
