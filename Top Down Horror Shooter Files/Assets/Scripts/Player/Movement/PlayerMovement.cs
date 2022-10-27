using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public PlayerManager player;

	private void Awake()
	{
		player = GetComponent<PlayerManager>();
	}

	public Vector2 GetInputVector()
	{
		Vector2 movement;

		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		return movement;
	}

	public void HandleMovement(float moveSpeed)
	{
		player.body.MovePosition(player.body.position + GetInputVector().normalized * moveSpeed * Time.fixedDeltaTime);
	}
}
