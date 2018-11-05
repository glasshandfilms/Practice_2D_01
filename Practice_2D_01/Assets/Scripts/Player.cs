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
	
	// Update is called once per frame
	void Update () {
        //when you press left click, fire
        
        float horizontalInput = Input.GetAxis("Horizontal") * speed;
        float verticalInput = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("shift was held down");
            transform.Translate(Vector3.right * horizontalInput * speed * speedburst * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * speedburst * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        }
        
        
        
        
	}
}
