using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SznukMovement : MonoBehaviour {

    public float moveRange = 3;
    public float speed = 2;
    public float missileSpeed = 4;
    public float cooldown = 1;
    public int hp = 100;
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
        if (Math.Abs(transform.position.x - startPos) > moveRange / 2)
            direction *= -1;

        shootDelta += Time.deltaTime;
        if (shootDelta > cooldown) {
            shootDelta = 0;
            Shoot();
        }

        transform.Translate(direction * speed * Vector3.right * Time.deltaTime);
    }

    void Shoot() {
        GameObject missile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Rigidbody rb = missile.AddComponent<Rigidbody>();
        missile.layer = 9;
        missile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        missile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        rb.velocity = new Vector3(0, missileSpeed, 0);
        
    }

    public void TakeDamage() {
        transform.localScale = new Vector3(0.9f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        hp -= 1;

        if (hp < 10) {
            Material mat = GetComponent<Material>();
            mat.SetTexture(0, Resources.Load("SznukLowHpFace"));
        }

        if (0 == hp)
            Destroy(gameObject);
    }
}
