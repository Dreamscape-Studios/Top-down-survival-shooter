using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory;

	public int inventorySize = 10;

	public float maxWeight = 10.0f;
	public float currentWeight;

	public bool AddItem(Item newItem)
	{
		if (inventory.Count >= inventorySize || 
			(currentWeight + newItem.weight) > maxWeight)
		{
			Debug.Log($"{newItem.name} could not be added. Max weight reached.");
			return false;
		}
		else
		{
			inventory.Add(newItem);
			Debug.Log($"{newItem.name} added to inventory.\n" +
				$"Inventory weight: {currentWeight}\n" +
				$"Items in inventory: {inventory.Count}");
			return true;
		}
	}

	public void RemoveItem(Item item)
	{
		inventory.Remove(item);
		Debug.Log($"{item.name} removed from inventory.\n" +
			$"Inventory weight: {currentWeight}\n" +
			$"Items in inventory: {inventory.Count}");
	}
}
