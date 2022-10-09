using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Image foodUIImage;
    [SerializeField] private TextMeshProUGUI foodNameUIText;
    [SerializeField] private TextMeshProUGUI foodCategoryUIText;
    [SerializeField] private TextMeshProUGUI foodDescriptionUIText;
    [SerializeField] private GameObject viewInformationSection;
    [SerializeField] private Sprite[] foodResources;
    [SerializeField] private Animator animator;

    public enum InformationStates { idle, viewInformationSection};
    public InformationStates informationState = InformationStates.idle;

    Dictionary<string, Dictionary<string, string>> foods = new();

    private void Start()
    {

        Dictionary<string, string> goFoods = new();
        goFoods.Add("Bread", "It has calories and carbohydrates that help keep the body moving.");
        goFoods.Add("Rice", "It's high in carbohydrates that gives the body energy.");

        Dictionary<string, string> growFoods = new();
        growFoods.Add("Egg", "Have a lot of protein, vitamins, and minerals that help the body grow.");
        growFoods.Add("Chicken", "It's high in protein, so it keeps the body strong.");
        growFoods.Add("Cheese", "Has calcium that keeps the bones strong.");

        Dictionary<string, string> glowFoods = new();
        glowFoods.Add("Apple", "Full of vitamins and antioxidants that can protect the body from diseases.");
        glowFoods.Add("Pumpkin", "High in potassium and vitamins that make muscles function.");
        glowFoods.Add("Banana", "Rich in potassium and moisture, which helps our skin stay soft and young.");

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

        informationState = InformationStates.viewInformationSection;
        animator.SetInteger("informationState", (int)informationState);

    }

    public void OnBack()
    {

        informationState = InformationStates.idle;
        animator.SetInteger("informationState", (int) informationState);

    }

}
