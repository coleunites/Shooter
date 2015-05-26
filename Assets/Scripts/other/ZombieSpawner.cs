using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour 
{
	public GameObject zombie;
	public float spawnFactor;
	float secondsCalc;
	// Use this for initialization
	void Start () 
	{
		secondsCalc = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		secondsCalc += (1 * Time.deltaTime);
		if(secondsCalc >= 5f)
		{
			Vector3 temp;
			for(int i = 0; i < (18 - (TimeTracker.Instance.secondsLeft * spawnFactor)); ++i)
			{
				temp = transform.position;
				temp.x += (float) i * 0.1f;
				Instantiate (zombie, temp, transform.rotation);
			}
			secondsCalc = 0f;
		}
	}
}
