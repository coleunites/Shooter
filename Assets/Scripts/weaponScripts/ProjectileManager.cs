using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

	public static ProjectileManager Instance;
	public GameObject[] projectiles;
	[HideInInspector]
	public float range = 0.0f;
	[HideInInspector]
	public int damage = 0;

	// Use this for initialization
	void Awake () 
	{
		Instance = this;
	}

	public void Spawn(string name, Vector3 postion, Quaternion rotation)
	{
		foreach(GameObject pt in projectiles)
		{
			if(pt.name == name)
			{
				Instantiate (pt, postion, rotation);
				return;
			}
		}
		Debug.Log ("cannot find projectile" + name);
	}

}
