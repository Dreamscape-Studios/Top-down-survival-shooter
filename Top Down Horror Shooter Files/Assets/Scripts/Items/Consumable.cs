using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumable", menuName = "Items/New Consumable")]
public class Consumable : Item
{
	public enum ConsumableTypes
	{
		Medkit,
		Bandage,
		Food,
		Drink
	}

	public ConsumableTypes type;

	public int health;
	public int calories;
	public int hydration;

	public void Use(PlayerManager player)
	{
		if (type == ConsumableTypes.Medkit)
		{
			player.health += health;
		}
		if (type == ConsumableTypes.Bandage)
		{
			player.bleeding = false;
		}
		if (type == ConsumableTypes.Food)
		{
			player.calories += calories;
		}
		if (type == ConsumableTypes.Drink)
		{
			player.hydration += hydration;
		}
	}
}
