using UnityEngine;
using System.Collections;

public class ExplosionSensor : MonoBehaviour 
{
	[HideInInspector]
	public int damage = 0;

	void OnTriggerEnter(Collider other)
	{
		if(other.isTrigger == false)
		{
			Health health = other.collider.GetComponentInParent<Health>();
			
			if(health)
			{
				VFXManger.Instance.Spawn ("bloodSplatter", other.collider.transform.position, Quaternion.identity);
				health.TakeDamage(damage);//
				Debug.Log ("HitTrigger");
			}
		}
	}
}
