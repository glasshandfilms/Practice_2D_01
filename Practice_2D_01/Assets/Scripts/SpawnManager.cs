﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    //making enemies
    //make powerups

    //spawn enemy after each random number of frames

    public List<GameObject> enemy = new List<GameObject> () ;
    public List<GameObject> powerups = new List<GameObject> ();
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnEnemies()
    {
        while (gameManager.gameOver == false)
        {          
            Instantiate(enemy[Random.Range(0, enemy.Count)], new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
        

    }

    IEnumerator SpawnPowerUps()
    {
        while(gameManager.gameOver == false)
        {
            Instantiate(powerups[Random.Range(0, powerups.Count)], new Vector3(Random.Range(-8.5f,8.5f), 7f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
}
