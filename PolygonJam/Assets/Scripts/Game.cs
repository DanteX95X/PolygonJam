﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	[SerializeField]
	Vector2 gridSize = new Vector2(0,0);

	[SerializeField]
	GameObject border = null;

	[SerializeField]
	GameObject answer = null;


	List<GameObject> borders = new List<GameObject>();
	List<Answer> answers = new List<Answer>();
	GameObject player = null;

	int properAnswerIndex = -1;

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

		NextQuestion();
	}
	
	void Update ()
	{
		for(int i = 0; i < answers.Count; ++i)
		{
			if(answers[i].IsChosen)
			{
				if (i == properAnswerIndex)
					Debug.Log("Git");
				else
					Debug.Log("Zjebałeś");

				NextQuestion();
			}
		}
	}

	void NextQuestion()
	{
		foreach(Answer obj in answers)
			Destroy(obj.gameObject);
		answers = new List<Answer>();

		answers.Add(Instantiate(answer, RandomPosition(), transform.rotation).GetComponent<Answer>());
		answers.Add(Instantiate(answer, RandomPosition(), transform.rotation).GetComponent<Answer>());

		answers[0].GetComponent<Renderer>().material.color = Color.red;
		answers[1].GetComponent<Renderer>().material.color = Color.green;

		int questionIndex = Random.Range(0, 100000);

		questionIndex %= Question.questions.Count;
		GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>().text = Question.questions[questionIndex].QuestionText + "?";
		properAnswerIndex = Question.questions[questionIndex].AnswerIndex;
	}

	public Vector3 RandomPosition()
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
