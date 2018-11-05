using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject player; 
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedburst;
    //make a firing cooldown


	
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
        
    }

    private void Laser ()
    {

    }



}
