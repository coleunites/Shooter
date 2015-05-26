using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoTracker : MonoBehaviour 
{
	static public AmmoTracker Instance;
	public bool reloading;

	Text ammoText;
	int ammo;
	int maxAmmo;
	float currentReloadTime;
	public float secondsCalc;
	// Use thiss for initialization
	void Start () 
	{
		Instance = this;
		ammoText = GetComponent<Text> ();
		ammoText.text = "45/45";
		reloading = false;
		ammo = 45;
		maxAmmo = ammo;
		secondsCalc = 0.0f;
		currentReloadTime = 0.125f;
	}

	public void SwitchAmmo(int ammoVal, float reloadTime)
	{
		ammo = ammoVal;
		maxAmmo = ammo;
		ammoText.text = ammo.ToString () + "/" + maxAmmo.ToString ();
		reloading = false;
		currentReloadTime = reloadTime;
	}

	public void SubTractAmmo()
	{
		ammo -= 1;
		ammoText.text = ammo.ToString () + "/" + maxAmmo.ToString ();
		if (ammo == 0)
		{
			reloading = true;
		}
	}


	// Update is called once per frame
	void Update() 
	{
		if(reloading == true)
		{
			secondsCalc += (1 * Time.deltaTime);
			if(secondsCalc >= currentReloadTime)
			{
				ammo+= 1;
				secondsCalc = 0f;
				ammoText.text = ammo.ToString () + "/" + maxAmmo.ToString ();
				if(ammo == maxAmmo)
				{
					reloading = false;
				}
			}
		}
	}


}
