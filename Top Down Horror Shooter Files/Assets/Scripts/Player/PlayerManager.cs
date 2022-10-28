using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
	#region component references
	[HideInInspector] public PlayerMovement movement;
	[HideInInspector] public PlayerRotation rotation;
	[HideInInspector] public PlayerInventory inventory;
	[HideInInspector] public Pickup pickup;
	[HideInInspector] public UserInterface ui;
	[HideInInspector] public Rigidbody2D body;
	[HideInInspector] public Camera cam;
	public Transform gunHand;
	public Light2D globalLight;
	
	#endregion

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
		ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UserInterface>();

		Debug.Log("Finished PlayerManager init");

		globalLight.intensity = 0;
	}
	#endregion

	#region variables
	[Header("Attributes")]
	public float health; // int out of 20
	public float maxHealth = 20;
	public float calories; // int out of 1000
	public float maxCalories = 1000;
	public float hydration; // percent out of 100
	public float maxHydration = 100;

	[Header("Movement")]
	public float moveSpeed = 3.0f;
	public float rotationSpeed = 10.0f;

	[Header("Interaction")]
	public float pickupDistance = 2.0f;

	[Header("States")]
	public bool bleeding = false;
	public float bleedingMagnitude = 0;
	#endregion

	private void Update()
	{
		InputManager();
		ui.UpdateText(health, maxHealth, calories, maxCalories, hydration, 
			maxHydration, inventory.medkits, inventory.bandages,
			inventory.food, inventory.drinks);
		if (bleeding)
			ApplyBleeding(bleedingMagnitude);

		if (inventory.equippedGun != null)
		{
			inventory.equippedGun.timeTillFire -= Time.deltaTime;
		}
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

	private void ApplyBleeding(float mag)
	{
		health -= (mag / 10) * Time.deltaTime;
	}

	private void InputManager()
	{
		if (Input.GetMouseButton(0))
		{
			if (inventory.equippedGun != null)
			{
				inventory.equippedGun.Fire();
			}
		}
		if (Input.GetMouseButtonDown(1))
		{
			pickup.CheckForItem(GetMousePos(), pickupDistance);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			inventory.UseMedkit(instance);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			inventory.UseBandage(instance);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			inventory.UseFood(instance);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			inventory.UseDrink(instance);
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(transform.position, GetMousePos() - transform.position); // draws ray to player mouse position
	}
}
