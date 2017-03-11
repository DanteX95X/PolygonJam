using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	Rigidbody2D body = null;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    float missileSpeed = 5;

    [SerializeField]
    Material fireballMat;

    public bool hasFireball = true;
    int hp = 3;

	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		body.velocity += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space) && hasFireball)
            Shoot();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        if ("Sznukball" == collision.gameObject.name)
            hp--;

        GameObject HPText = GameObject.FindGameObjectWithTag("HP Text");
        if (HPText) {
            Text txt = HPText.GetComponent<Text>();
            txt.text = "HP " + hp;
        }

        if (0 == hp)
            Destroy(gameObject);
	}

    void Shoot() 
    {
        //hasFireball = false;
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
    }
}
