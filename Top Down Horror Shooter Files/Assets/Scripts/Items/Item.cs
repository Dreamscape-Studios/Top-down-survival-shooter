using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
	new public string name;
	public string description;

	public Sprite icon;

	public float weight;
}