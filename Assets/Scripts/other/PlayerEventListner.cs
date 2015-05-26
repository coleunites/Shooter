using UnityEngine;
using System.Collections;

public class PlayerEventListner : MonoBehaviour 
{
	void Start()
	{

	}

	public void DamageRecieved(float percentage)
	{
		HealthTracker.Instance.SubtractHealth (percentage);
		Health health = GetComponent<Health> ();
		if(health.isAlive == false)
		{
			ConditionTracker.Instance.Lost();
		} 
	}
}
