using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[Header("Script References")]
	public PlayerMovement movement;
	public PlayerRotation rotation;
	public PlayerInventory inventory;
	public Pickup pickup;

	[Header("Component References")]
	public Rigidbody2D body;
	public Camera cam;

	#region init
	public static PlayerManager instance;
	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of player manager found!!");
			return;
		}
		else
			instance = this;

		body = GetComponent<Rigidbody2D>();
		cam = Camera.main;
		movement = GetComponent<PlayerMovement>();
		rotation = GetComponent<PlayerRotation>();
		inventory = GetComponent<PlayerInventory>();
		pickup = GetComponent<Pickup>();

		Debug.Log("Finished PlayerManager init");
	}
	#endregion

	[Header("Movement")]
	public float moveSpeed;
	public float rotationSpeed;

	[Header("Interaction")]
	public float pickupDistance;

	private void Update()
	{
		InputManager();
	}

	private void FixedUpdate()
	{
		movement.HandleMovement(moveSpeed);
		rotation.HandleRotation(GetMousePos(), rotationSpeed);
	}

	private Vector3 GetMousePos()
	{
		return cam.ScreenToWorldPoint(Input.mousePosition);
	}
	private void InputManager()
	{
		if (Input.GetMouseButtonDown(1))
			pickup.CheckForItem(GetMousePos(), pickupDistance);
	}
}
