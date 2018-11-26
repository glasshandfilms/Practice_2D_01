using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    //update our display for lives
    //update our display for fuel

    public Sprite[] livesSprites;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score;
    public GameObject titleScreen;
    public Slider fuelSlider;
    public float fuelCount;
    public Text spaceStart;

    void Start()
    {
        spaceStart.text = "Welcome to Galaxy Shooter!";
    }

    


    public void UpdateLives(int currentLives)
    {
        //Debug.Log("Player lives: " + currentLives);
        livesImageDisplay.sprite = livesSprites[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;

        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        fuelSlider.value = fuelCount;
    }

    public void ShowTitleScreen()
    {
        spaceStart.text = "Get Ready!";
        titleScreen.SetActive(true);
    }
    
    public void HideTitleScreen()
    {

        titleScreen.SetActive(false);
        scoreText.text = "Score: ";
    }

    public void ShowSpaceStart()
    {
        spaceStart.text = "Press Space to Start";
    }
}
