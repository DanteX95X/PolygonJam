using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	Vector2 gridSize = new Vector2(0,0);

	[SerializeField]
	GameObject border = null;

	[SerializeField]
	GameObject answer = null;


	List<GameObject> borders = new List<GameObject>();
	List<GameObject> answers = new List<GameObject>();
	GameObject player = null;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		borders.Add(Instantiate(border, new Vector3(0, Mathf.Ceil(gridSize.y/2+1), 0), transform.rotation) as GameObject);
		borders.Add(Instantiate(border, new Vector3(0, -Mathf.Ceil(gridSize.y/2+1), 0), transform.rotation) as GameObject);
		borders.Add(Instantiate(border, new Vector3(Mathf.Ceil(gridSize.x / 2+1), 0, 0), transform.rotation) as GameObject);
		borders.Add(Instantiate(border, new Vector3(-Mathf.Ceil(gridSize.x / 2+1), 0, 0), transform.rotation) as GameObject);

		for(int i = 0; i < borders.Count; ++i)
		{
			if(i < 2)
			{
				borders[i].transform.localScale = new Vector3(gridSize.x+1, 1, 1);
			}
			else
			{
				borders[i].transform.localScale = new Vector3(1, gridSize.y+1, 1);
			}
		}
	}
	
	void Update ()
	{
		if (Input.GetKey(KeyCode.Space))
			NextQuestion();
	}

	void NextQuestion()
	{
		foreach(GameObject obj in answers)
			Destroy(obj);

		answers.Add(Instantiate(answer, RandomPosition(), transform.rotation) as GameObject);
	}

	Vector3 RandomPosition()
	{
		Vector3 position;
		do
		{
			position = new Vector3(Random.RandomRange(-gridSize.x, gridSize.x) / 2, Random.RandomRange(-gridSize.y, gridSize.y) / 2, -1);
		}
		while (Mathf.Abs(position.x - player.transform.position.x) < 1 || Mathf.Abs(position.y - player.transform.position.y) < 1);
		return position;
	}
}
