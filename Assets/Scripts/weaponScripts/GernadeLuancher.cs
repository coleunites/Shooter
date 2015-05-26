using UnityEngine;
using System.Collections;

public class GernadeLuancher : Weapon
{
	public Transform muzzleTransform;

	public override void Fire()
	{
		if(AmmoTracker.Instance.reloading == false)
		{
			AmmoTracker.Instance.SubTractAmmo();
			ProjectileManager.Instance.range = range;
			ProjectileManager.Instance.damage = damage;
			ProjectileManager.Instance.Spawn ("Geranade", muzzleTransform.position, transform.rotation);
		}
	}
}
