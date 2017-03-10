using UnityEngine;
using System.Collections;

public class ActualGameplay : MonoBehaviour {

	public float[] timings;
	public int currentTiming;

	void Awake()
	{
		timings = new float[3];
		timings [0] = 20.0f;//green
		timings [1] = 20.0f;//purple
		timings [2] = 20.0f;//red
	}
	// Use this for initialization
	void Start () {
		currentTiming = 0;
		StartCoroutine (Wait (timings[currentTiming]));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Wait(float time)
	{
		yield return new WaitForSeconds (time);
		activeSpawns (currentTiming + 1);
		currentTiming++;
		if (currentTiming < timings.Length) 
		{
			StartCoroutine (Wait (timings [currentTiming]));
		}
	}

	public void activeSpawns(int id)
	{
		SpawnOtherThanSlime.activeTurn = id;
	}

}
