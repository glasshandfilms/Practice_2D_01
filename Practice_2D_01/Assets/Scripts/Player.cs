using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject _player; 
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _speedburst;
    [SerializeField]
    private GameObject _laser;
    //make a firing cooldown

    private float _canFire = 0f;
    [SerializeField]
    private float _fireRate = 0.25f;



	
	void Start () {

        transform.position = new Vector3(0, 0, 0);    
                
	}
	
	
	void Update () {

        PlayerMovement();
        Laser();
        
        
        
	}

    private void PlayerMovement ()
    {   
        //Player Keys and SpeedBurst Check
        float horizontalInput = Input.GetAxis("Horizontal") * _speed;
        float verticalInput = Input.GetAxis("Vertical") * _speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * _speedburst * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * _speed * _speedburst * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
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
        
    }

    private void Laser ()
    {
        Shoot();       
    }

    private void Shoot ()
    {
        if (Input.GetButtonDown("Fire1") || (Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0)))
        {
            if (Time.time > _canFire)
            {
                //Debug.Log("Fire was pressed");
                Instantiate(_laser, transform.position + new Vector3(0, 0.98f, 0), Quaternion.identity);
                _canFire = Time.time + _fireRate;
            }


        }
    }

}
