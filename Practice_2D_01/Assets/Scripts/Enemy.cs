using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    [SerializeField] private GameObject laser;
		
	void Update () {
        transform.position += new Vector3(0, -enemySpeed * Time.deltaTime, 0);
        if(transform.position.y < -8)
        {
            Destroy(gameObject);
        }

        if(transform.position.y <= 4)
        {
            Instantiate(laser, transform.position + new Vector3(0, 0.98f, 0), Quaternion.identity);
        }


	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("PlayerLaser"))
        {
            Destroy(gameObject);
        }
    }
}
