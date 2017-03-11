using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D body = null;

	[SerializeField]
	float speed = 5;


	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(Input.GetAxis("Horizontal") + " " + Input.GetAxis("Vertical"));
		body.velocity += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
