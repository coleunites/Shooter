using UnityEngine;
using System.Collections;

public class Geranade : MonoBehaviour {

	public float speed;

	float secondCalc;
	int damage = 0;
	bool boom = false;


	// Use this for initialization
	void Start () 
	{
		rigidbody.AddForce (transform.forward * ProjectileManager.Instance.range * speed);
		damage = ProjectileManager.Instance.damage;
		boom = false;
		secondCalc = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		secondCalc += (1 * Time.deltaTime);
		if(secondCalc >= 3f)
		{
			boom = true;
		}
		if(secondCalc >= 3.1f)
		{
			Destroy (gameObject);
		}
		
	}
	

	void OnTriggerStay(Collider other)
	{
		if(boom == true )
		{
			Health health = other.collider.GetComponentInParent<Health>();
			
			if(health && (Vector3.Distance (transform.position, other.transform.position) <= 5.0f))
			{
				VFXManger.Instance.Spawn ("bloodSplatter", other.collider.transform.position, Quaternion.identity);
				health.TakeDamage(damage);//
			}
		}
	}
}
