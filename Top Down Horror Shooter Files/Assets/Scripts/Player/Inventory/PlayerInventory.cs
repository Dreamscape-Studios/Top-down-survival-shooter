using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory;

	public GunScript equippedGun;

	public int inventorySize = 10;

	public float maxWeight = 10.0f;
	public float currentWeight;

	public int medkits;
	public int bandages;
	public int food;
	public int drinks;

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
			if (newItem is Consumable consumable)
			{
				if (consumable.type == Consumable.ConsumableTypes.Medkit)
					medkits++;
				if (consumable.type == Consumable.ConsumableTypes.Bandage)
					bandages++;
				if (consumable.type == Consumable.ConsumableTypes.Food)
					food++;
				if (consumable.type == Consumable.ConsumableTypes.Drink)
					drinks++;
			}

			if (newItem is Gun gun)
			{
				Transform sprite = transform.Find("Player Graphics");
				equippedGun = Instantiate(gun.obj, PlayerManager.instance.gunHand.position, 
					sprite.transform.rotation, sprite).GetComponent<GunScript>();
				equippedGun.init(gun);
			}

			Debug.Log($"{newItem.name} added to inventory.\n" +
				$"Inventory weight: {currentWeight} Items in inventory: {inventory.Count}");
			return true;
		}
	}

	public void RemoveItem(Item item)
	{
		inventory.Remove(item);
		Debug.Log($"{item.name} removed from inventory.\n" +
			$"Inventory weight: {currentWeight} Items in inventory: {inventory.Count}");
	}

	public void UseGun()
	{

	}
	public void UseMedkit(PlayerManager player)
	{
		if (medkits > 0)
		{
			foreach (Item item in inventory)
			{
				if (item is Consumable consumable)
				{
					if (consumable.type == Consumable.ConsumableTypes.Medkit)
					{
						consumable.Use(player);
						medkits--;
						RemoveItem(item);
						return;
					}
				}
			}
		}
		else
			Debug.Log("NO MEDKITS!");
	}
	public void UseBandage(PlayerManager player)
	{
		if (bandages > 0)
		{
			foreach (Item item in inventory)
			{
				if (item is Consumable consumable)
				{
					if (consumable.type == Consumable.ConsumableTypes.Bandage)
					{
						consumable.Use(player);
						bandages--;
						RemoveItem(item);
						return;
					}
				}
			}
		}
		else
			Debug.Log("NO BANDAGES!");
	}
	public void UseFood(PlayerManager player)
	{
		if (food > 0)
		{
			foreach (Item item in inventory)
			{
				if (item is Consumable consumable)
				{
					if (consumable.type == Consumable.ConsumableTypes.Food)
					{
						consumable.Use(player);
						food--;
						RemoveItem(item);
						return;
					}
				}
			}
		}
		else
			Debug.Log("NO FOOD!");
	}
	public void UseDrink(PlayerManager player)
	{
		if (drinks > 0)
		{
			foreach (Item item in inventory)
			{
				if (item is Consumable consumable)
				{
					if (consumable.type == Consumable.ConsumableTypes.Drink)
					{
						consumable.Use(player);
						drinks--;
						RemoveItem(item);
						return;
					}
				}
			}
		}
		else
			Debug.Log("NO DRINKS!");
	}
}
