using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageHUD : MonoBehaviour 
{
	public static DamageHUD Instance;

	public float speed;

	Image damage;
	float lerp = 0f;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		damage = GetComponent<Image> ();
		damage.color = Color.clear;
	}

	void Update()
	{
		lerp = Mathf.Lerp (lerp, 0f, Time.deltaTime * speed);
		damage.color = Color.Lerp(Color.clear, Color.white, lerp);
	}

	public void OnPlayerHit()
	{
		lerp = 1f;
	}
}
