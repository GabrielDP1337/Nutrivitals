using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Image foodUIImage;
    [SerializeField] private TextMeshProUGUI foodNameUIText;
    [SerializeField] private TextMeshProUGUI foodCategoryUIText;
    [SerializeField] private TextMeshProUGUI foodDescriptionUIText;
    [SerializeField] private GameObject viewInformationSection;
    [SerializeField] private Sprite[] foodResources;

    Dictionary<string, Dictionary<string, string>> foods = new();

    private void Start()
    {

        Dictionary<string, string> goFoods = new();
        goFoods.Add("Apple", "Apple is a Go Food");

        Dictionary<string, string> glowFoods = new();
        glowFoods.Add("", "");

        Dictionary<string, string> growFoods = new();
        growFoods.Add("", "");

        foods.Add("Go Food", goFoods);
        foods.Add("Glow Food", glowFoods);
        foods.Add("Grow Food", growFoods);

    }

    public void OnViewInformation(string _fruit)
    {

        if (viewInformationSection.activeInHierarchy == false)
        {

            viewInformationSection.SetActive(true);

        }

        foreach (Sprite food in foodResources)
        {

            if (food.name.ToLower() == _fruit.ToLower())
            {

                foodUIImage.sprite = food;

            }

        }

        foreach (var food in foods)
        {
            
            string category = food.Key;

            foreach (var item in foods[category])
            {

                if (item.Key == _fruit)
                {

                    foodCategoryUIText.text = category;
                    foodDescriptionUIText.text = item.Value;

                }

            }

        }

        foodNameUIText.text = _fruit;

    }

}
