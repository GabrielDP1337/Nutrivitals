using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static float gameScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameScore += 5 * Time.deltaTime;
        scoreText.text = "Score:" + Mathf.Round (gameScore);
    }

}
