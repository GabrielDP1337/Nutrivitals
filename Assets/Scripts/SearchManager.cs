using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchManager : MonoBehaviour
{
    
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject[] foods;
    [SerializeField] private GameObject searchHUD;
    [SerializeField] private int totalFoods;

    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject dropDownUIButton;

    private void Start()
    {

        totalFoods = content.transform.childCount;

        foods = new GameObject[totalFoods];

        for (int i = 0; i < totalFoods; i++)
        {

            foods[i] = content.transform.GetChild(i).gameObject;

        }

    }

    private void Update()
    {
        
        if (dropDownUIButton.GetComponent<Toggle>().isOn)
        {

            scrollView.SetActive(true);

        }
        else
        {

            scrollView.SetActive(false);

        }

    }

    public void Search()
    {

        string SearchText = searchHUD.GetComponent<TMP_InputField>().text;
        int searchTextLength = SearchText.Length;

        int searchElements = 0;

        foreach (GameObject ele in foods)
        {

            searchElements += 1;

            if (ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length >= searchTextLength)
            {

                if (SearchText.ToLower() == ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0, searchTextLength).ToLower())
                {

                    ele.SetActive(true);

                }
                else
                {

                    ele.SetActive(false);

                }    

            }

        }

    }

}
