using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	PlayerManager player;

	public float moveSpeed;

	Vector2 movement;

	private void Awake()
	{
		player = GetComponent<PlayerManager>();
	}
	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	}
	private void FixedUpdate()
	{
		player.body.MovePosition(player.body.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}
}
