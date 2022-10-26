using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
	PlayerManager player;
	[SerializeField] Transform sprite;
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
		sprite.transform.rotation = Quaternion.Lerp(sprite.transform.rotation, 
			Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
	}
}
