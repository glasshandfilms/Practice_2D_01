using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public static int laserColorID;
    [SerializeField] private float laserSpeed;
    public Color[] colors;

    private void Start()
    {
        laserColorID++; if (laserColorID == colors.Length) laserColorID = 0;
        GetComponent<SpriteRenderer>().color = colors[laserColorID];
    }

    void Update () {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if (transform.position.y > 9f || transform.position.y <-9f)
        {
            Destroy(this.gameObject);


        }

	}
}
