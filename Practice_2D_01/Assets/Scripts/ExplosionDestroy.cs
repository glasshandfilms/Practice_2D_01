using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour {

	
	
	IEnumerator ExplosionLife()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        StartCoroutine(ExplosionLife());
    }
}
