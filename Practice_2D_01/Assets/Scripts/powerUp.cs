using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour {

    public enum Type { TripleShot, Shield }
    
    [SerializeField] private float speed;
    
    public Type type;

	
	void Start () {
		
	}
	
	
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.CompareTag("Player"))
        {

            Player player = other.GetComponent<Player>();
            if (player)
            {
                if(type == Type.TripleShot)
                {
                    player.ActivatePowerUp(type);
                    
                }
                else if(type == Type.Shield)
                {
                    player.shieldActivated = true;
                    
                }

                Destroy(this.gameObject);
            }
        }
        if (other.transform.CompareTag("PlayerLaser"))
        {
            Destroy(gameObject); 
        }
        

    }
}
