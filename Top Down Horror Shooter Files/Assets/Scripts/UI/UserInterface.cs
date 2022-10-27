using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
	#region components
	public Text healthText;
    public Text calorieText;
    public Text hydrationText;
	public Text medkitText;
	public Text bandageText;
	public Text foodText;
	public Text drinkText;
	#endregion

	#region init
	public static UserInterface instance;
	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of user interface found!!");
			return;
		}
		instance = this;
	}
	#endregion

	public void UpdateText(float health, float maxHealth, float calories, 
		float maxCalories, float hydration, float maxHydration, int medkits, int bandages,
		int food, int drinks)
	{
		healthText.text = $"Health: {(int)health} / {maxHealth}";
		calorieText.text = $"Calories: {(int)calories} / {maxCalories}";
		hydrationText.text = $"Hydration: {(int)hydration} / {maxHydration}";
		medkitText.text = $"Medkits: {medkits}";
		bandageText.text = $"Bandages: {bandages}";
		foodText.text = $"Food: {food}";
		drinkText.text = $"Drinks: {drinks}";
	}
}
