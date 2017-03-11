using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (("Fireball" == gameObject.name && "Sznuk" == collision.gameObject.name) ||
            ("Sznukball" == gameObject.name && "Player" == collision.gameObject.name))
            Destroy(gameObject);
    }
}
