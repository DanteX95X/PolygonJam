using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SznukMovement : MonoBehaviour {

    public float moveRange = 3;
    public float speed = 2;
    public float missileSpeed = 4;
    public float cooldown = 1;
    public int hp = 3;
    public Material lowHp;

    float startPos;
    float direction = 1;
    float shootDelta = 0;

    // Use this for initialization
    void Start() {
        startPos = transform.position.x;
        transform.localScale = new Vector3(3 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x - startPos > moveRange / 2)
            direction = -1;
        if (transform.position.x - startPos < -moveRange / 2)
            direction = 1;

        shootDelta += Time.deltaTime;
        if (shootDelta > cooldown) {
            shootDelta = 0;
            Shoot();
        }

        transform.Translate(direction * speed * Vector3.right * Time.deltaTime);
    }

    void Shoot() {
        GameObject missile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        DestroyImmediate(missile.GetComponent<SphereCollider>());
        Rigidbody2D rb = missile.AddComponent<Rigidbody2D>();
        missile.AddComponent<CircleCollider2D>();
        missile.AddComponent<Missile>();

        missile.name = "Sznukball";
        missile.layer = 9;
        missile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        missile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        rb.velocity = new Vector2(0, missileSpeed);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;

	}

    public void TakeDamage() {
        transform.localScale = new Vector3(0.9f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        hp -= 1;

        if (hp < 2) {
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = lowHp;
        }

		if (0 == hp)
		{
			GetComponent<AudioSource>().Play();
			SceneManager.LoadScene("Game");
			Destroy(gameObject);
		}
    }

    private void OnCollisionEnter2D(Collision2D collision) {
		if ("Fireball" == collision.gameObject.name)
		{
			TakeDamage();
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().PlayAudio(3);
		}
    }
}
