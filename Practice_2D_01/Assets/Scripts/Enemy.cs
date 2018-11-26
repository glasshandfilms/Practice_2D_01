using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    [SerializeField] private GameObject laser;
    public GameObject enemyExplosionPrefab;
    private UIManager uiManager;
    private Player player;


    private void Start()
    {
        StartCoroutine(EnemyFireRate());

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
    }
    
    void Update () {
        transform.position += new Vector3(0, -enemySpeed * Time.deltaTime, 0);
        if(transform.position.y < -8)
        {
            Destroy(gameObject);
        }

        if(transform.position.y <= 4.5)
        {
            EnemyFireRate();
        }


	}

    IEnumerator EnemyFireRate()
    {
        while(true)
        {
            Instantiate(laser, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f,2f));
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("PlayerLaser"))
        {
            Destroy(other.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            uiManager.UpdateScore();
            Destroy(gameObject);
        }
        if (other.transform.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
            

        }
        

    }
}
