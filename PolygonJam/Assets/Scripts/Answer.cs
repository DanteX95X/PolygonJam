using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
	bool isChosen;

	public bool IsChosen
	{
		get { return isChosen; }
	}


	void Start ()
	{
		isChosen = false;
	}
	
	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			isChosen = true;
		}
		else
		{
			transform.position = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().RandomPosition();
		}
	}
}
