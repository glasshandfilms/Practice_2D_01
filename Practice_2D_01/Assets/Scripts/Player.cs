using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject player; 
    [SerializeField]
    private float speed; 
    //make a firing cooldown


	
	void Start () {

        transform.position = new Vector3(0, 0, 0);
        

        
	}
	
	// Update is called once per frame
	void Update () {
        //when you press left click, fire
		//when you press left, move left
        //when you press right, move right
        //when you press up, move up
        //when you press down, move down
	}
}
