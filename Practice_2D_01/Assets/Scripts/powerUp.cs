using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour {

    [SerializeField]
    private float _speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //access the player
        //turn the triple shot to true
        //then destroy ourselves
        //need a handle to the component


        Player player = other.GetComponent<Player>();
        player.tripleShotActivated = true;
        Destroy(this.gameObject);

    }
}
