using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	Rigidbody2D body = null;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    float missileSpeed = 5;

    [SerializeField]
    Material fireballMat;
    [SerializeField]
    Material chargedMat;
    [SerializeField]
    Material unchargedMat;

    bool hasFireball = false;
    int hp = 3;

	public bool HasFireball
	{
		get { return hasFireball; }
		set { hasFireball = value; }
	}

	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        body.velocity += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * Time.deltaTime * speed;

        if (hasFireball) {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = chargedMat;
        }
        else {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = unchargedMat;
        }


        if (Input.GetKeyDown(KeyCode.Space) && hasFireball)
            Shoot();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ("Sznukball" == collision.gameObject.name)
		{
			hp--;
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().PlayAudio(2);
		}

        GameObject HPText = GameObject.FindGameObjectWithTag("HP Text");
        if (HPText) {
            Text txt = HPText.GetComponent<Text>();
            txt.text = "HP " + hp;
        }

		if (0 == hp)
		{
			GetComponent<AudioSource>().Play();
			SceneManager.LoadScene("Game");
			Destroy(gameObject);
		}
	}

    void Shoot() 
    {
        hasFireball = false;
        GameObject missile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        DestroyImmediate(missile.GetComponent<SphereCollider>());
        Rigidbody2D rb = missile.AddComponent<Rigidbody2D>();
        missile.AddComponent<CircleCollider2D>();
        missile.AddComponent<Missile>();
        Renderer renderer = missile.GetComponent<Renderer>();
        renderer.material = fireballMat;
        missile.name = "Fireball";
        missile.layer = 9;
        missile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        missile.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
        rb.velocity = new Vector2(0, -missileSpeed);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;

		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().PlayAudio(4);
	}
}
