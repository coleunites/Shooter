using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	public GameObject[] weapons;
	GameObject selectedWeapon;
	public Weapon currentWeapon;

	void Start ()
	{
		currentWeapon = GetComponentInChildren<Weapon> ();
		Screen.showCursor = false;
		selectedWeapon = weapons[0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentWeapon)
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				currentWeapon.Fire ();
			}
		}


		if(Input.GetButtonDown("weapon1"))
		{
			selectedWeapon.SetActive(false);
			weapons[0].SetActive(true);
			selectedWeapon = weapons[0];
			currentWeapon = GetComponentInChildren<Weapon> ();
			AmmoTracker.Instance.SwitchAmmo(45, 0.125f);
		}
		else
		{
			if(Input.GetButtonDown("weapon2"))
			{
				selectedWeapon.SetActive(false);
				weapons[1].SetActive(true);
				selectedWeapon = weapons[1];
				currentWeapon = GetComponentInChildren<Weapon> ();
				AmmoTracker.Instance.SwitchAmmo(3, 1f);
			}
		}
	}
}
