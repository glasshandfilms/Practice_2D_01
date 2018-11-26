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
        
        if (gameOver == true)
        {
            StartCoroutine(DeathCounter());
          
        }
    }

    IEnumerator DeathCounter()
    {
        yield return new WaitForSeconds(2f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(player, Vector3.zero, Quaternion.identity);
            gameOver = false;
            uiManager.HideTitleScreen();
        }
    }

}
