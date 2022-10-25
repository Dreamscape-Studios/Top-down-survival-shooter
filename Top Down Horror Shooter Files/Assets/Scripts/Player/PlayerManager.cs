using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public PlayerRotation playerRotation;

	public Rigidbody2D body;

	public Camera cam;
	#region singleton
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
		playerMovement = GetComponent<PlayerMovement>();
		playerRotation = GetComponent<PlayerRotation>();
	}
	#endregion
}
