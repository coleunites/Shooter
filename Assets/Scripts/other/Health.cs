using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	public int maxHealth;

	int health;
	[HideInInspector]
	public bool isAlive;
	void Start()
	{
		health = maxHealth;
		isAlive = true;
	}

	public void TakeDamage (int amount)
	{
		health -= amount;
		float percentage = (float)health / (float)maxHealth ;
		if (health <= 0) 
		{
			isAlive = false;
		}
		SendMessage ("DamageRecieved", percentage );
	}
}
