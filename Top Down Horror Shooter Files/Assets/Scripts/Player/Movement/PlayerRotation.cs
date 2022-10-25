using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
	PlayerManager player;
	Vector2 mousePos;

	public float rotationSpeed = 1.0f;

	private void Awake()
	{
		player = GetComponent<PlayerManager>();
	}
	private void Update()
	{
		mousePos = player.cam.ScreenToWorldPoint(Input.mousePosition);
	}
	private void FixedUpdate()
	{
		Vector2 lookDir = mousePos - player.body.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
		player.transform.rotation = Quaternion.Lerp(player.transform.rotation, 
			Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
	}
}
