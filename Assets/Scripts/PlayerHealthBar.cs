using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
	// PlayerHealth playerHealth = null;
	// int maxHP;

	// [SerializeField] float spacing = 5; 
	// [SerializeField] Image heartPrefab;

	// public List<GameObject> hearts;

	// void Start()
	// {
	// }

	// void Awake()
	// {
	// 	playerHealth = FindObjectOfType<PlayerHealth>();
	// }


	// // void Update()
	// // {
	// // 	if (playerHealth == null)
	// // 	{
	// // 		playerHealth = FindObjectOfType<PlayerHealth>();
	// // 		maxHP = playerHealth.maxHP;
	// // 		// CreateBar();
	// // 	}
	// // 	else
	// // 	{
	// // 		UpdateBar();
	// // 	}
		
	// // }

	// void CreateBar()
	// {
	// 	//Calculate the potential max width of the bar
	// 	//maxwidth = (image.maxwidth + spacing) * maxhp
	// 	// var maxWidth = (heartPrefab.flexibleWidth + spacing) * maxHP;
	// 	// var startPos = -maxWidth / 2f;

	// 	//Create the bar
	// 	// for (int i = 0; i < playerHealth.maxHP; i++)
	// 	// {
	// 	// 	//Add a new heart
	// 	// 	var newObj = new GameObject();
	// 	// 	// hearts.Add(gameObject.AddComponent<Image>());
	// 	// 	//Add a new image component
	// 	// 	var newImage = hearts[i].AddComponent<Image>();

	// 	// 	//Set the image
	// 	// 	// var tempImage = hearts[i].GetComponent<Image>();
			
	// 	// 	newImage.sprite = heartPrefab.sprite;
	// 	// 	// tempImage.sprite = Instantiate(heartPrefab.sprite, heartPrefab.rectTransform.position, heartPrefab.rectTransform.rotation);

	// 	// 	newObj.GetComponent<RectTransform>().SetParent(transform);

	// 	// 	//Set the position based on this
	// 	// 	newObj.GetComponent<RectTransform>().position.Set((startPos + spacing) * i, newImage.rectTransform.position.y, newImage.rectTransform.position.z);

	// 	// 	newObj.SetActive(true);

	// 	// 	hearts.Add(newObj);
	// 	// }
	// }

	// void UpdateBar()
	// {
	// 	for (int i = 0; i < maxHP; ++i)
	// 	{
	// 		var heartColor = hearts[i].GetComponent<Image>().color;
	// 		//Colour hearts red if they're below current hp
	// 		if (playerHealth.currentHP < i)	{
	// 			heartColor = Color.red;
	// 		}
	// 		else {
	// 			heartColor = Color.black;
	// 		}
	// 	}
	// }

}
