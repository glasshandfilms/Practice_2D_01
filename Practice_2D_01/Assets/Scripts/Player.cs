using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    

    [SerializeField] private GameObject player; 
    [SerializeField] private float speed;
    [SerializeField] private float speedburst;
    [SerializeField] private GameObject laser;
    private float canFire = 0f;
    [SerializeField] private float fireRate = 0.25f;
    public bool tripleShotActivated;
    public bool shieldActivated;
    [SerializeField] private GameObject tripleShot;
    float tripleShotTimer;
    float shieldTimer;
    public int lives;
    public GameObject explosionPrefab;
    public GameObject shieldGameObject;
    private UIManager uiManager;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;
    [SerializeField] private GameObject[] engines;
    private int hitCount = 0;



    void Start () {

        transform.position = new Vector3(0, 0, 0);

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(uiManager != null)
        {
            uiManager.UpdateLives(lives);
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if(spawnManager != null)
        {
            spawnManager.StartSpawnRoutines();
        }

        audioSource = GetComponent<AudioSource>();

        hitCount = 0;

	}
	
	
	void Update () {

        PlayerMovement();

        if (tripleShotActivated)
        {
            if(tripleShotTimer < Time.time)
            {
                tripleShotActivated = false;
            }
        }
        if (shieldActivated)
        {
            if (shieldTimer < Time.time)
            {
                shieldActivated = false;
                shieldGameObject.SetActive(false);
            }
        }

        
        
	}

    private void PlayerMovement ()
    {   
        //Player Keys and SpeedBurst Check
        float horizontalInput = Input.GetAxis("Horizontal") * speed;
        float verticalInput = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.right * horizontalInput * speed * speedburst * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * speedburst * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        }


        //Player Boundaries
        if (transform.position.x > 8.75f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.75f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
       
        if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, 4, 0);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        //Player Fire Input
        if (Input.GetButtonDown("Fire1") || (Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0)))
        {
            Shoot();
        }


    }

    

    private void Shoot ()
    {
        if (Time.time > canFire)
        {
            audioSource.Play();
            if (tripleShotActivated == true)
            {
                Instantiate(tripleShot, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
            else

            {
                //Debug.Log("Fire was pressed");
                Instantiate(laser, transform.position + new Vector3(0, 0.98f, 0), Quaternion.identity);
                
            }

            canFire = Time.time + fireRate;
        }
            


        
    }


    public void ActivatePowerUp (PowerUp.Type type)
    {
        if(type == PowerUp.Type.TripleShot)
        {
            tripleShotActivated = true;
            tripleShotTimer = Time.time + 10f;
        }
        else if(type == PowerUp.Type.Shield)
        {
            shieldActivated = true;
            shieldGameObject.SetActive(true);
            shieldTimer = Time.time + 10f;
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("EnemyLaser"))
        {
            Damage();
            Debug.Log("Player damage");
        }
    }

    public void Damage()
    {
        //subtract 1 life from player on hit
        //if player has shields, do nothing
        

        if(shieldActivated == true)
        {
            //shieldActivated = false;
            return;
        }

        hitCount++;

        if (hitCount == 1)
        {
            engines[0].SetActive(true);
        }
        else if (hitCount == 2)
        {
            engines[1].SetActive(true);
        }

        lives--;
        uiManager.UpdateLives(lives);

        if(lives < 1)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager.gameOver = true;
            uiManager.ShowTitleScreen();
        }
            
              
    }




}
