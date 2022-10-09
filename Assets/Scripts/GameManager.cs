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
        goFoods.Add("Bread", "Lorem epsum");
        goFoods.Add("Rice", "Lorem epsum");

        Dictionary<string, string> growFoods = new();
        growFoods.Add("Egg", "Lorem epsum");
        growFoods.Add("Chicken", "Lorem epsum");
        growFoods.Add("Cheese", "Lorem epsum");

        Dictionary<string, string> glowFoods = new();
        glowFoods.Add("Apple", "Lorem epsum");
        glowFoods.Add("Pumpkin", "Lorem epsum");
        glowFoods.Add("Banana", "Lorem epsum");

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
