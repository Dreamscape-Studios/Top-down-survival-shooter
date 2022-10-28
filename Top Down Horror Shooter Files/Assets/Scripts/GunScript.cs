using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
	public Gun gunItem;
	public GameObject bulletPrefab;

	public Transform firePoint;

	public Vector4 shakeAmount;

	public float damage;
	public float stoppingPower;
	public float condition;
	public float fireRate;
	public float timeTillFire;
	public int magazineSize;
	public int ammo;

	public void init(Gun gun)
	{
		damage = gun.damage;
		stoppingPower = gun.stoppingPower;
		condition = gun.condition;
		fireRate = gun.fireRate;
		magazineSize = gun.magazineSize;
		ammo = magazineSize;
	}

	public void Fire()
	{
		if (timeTillFire <= 0)
		{
			CameraShaker.Instance.ShakeOnce(1.5f, 10f, 0.1f, 0.5f);
			timeTillFire = fireRate;
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
			Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
			bulletBody.AddForce(transform.up * 20, ForceMode2D.Impulse);
			bullet.GetComponent<ProjectileBehaviour>().damage = damage;
			ammo--;
			timeTillFire = fireRate;
		}
	}
}
