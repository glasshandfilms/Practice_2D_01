using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    private UIManager uiManager;
    //if game over is true
    //if space key is pressed
    //spawn the player
    //game over is false
    //hide title screen

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if(gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) || (Input.GetButtonDown("Fire1")) || (Input.GetMouseButtonDown(0)))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                uiManager.HideTitleScreen();
            }
        }
    }

}
