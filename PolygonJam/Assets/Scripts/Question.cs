using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Pair
{
	string questionText;
	int answerIndex;

	public string QuestionText
	{
		get { return questionText; }
	}
	public int AnswerIndex
	{
		get { return answerIndex; }
	}

	public Pair(string questionText, int answerIndex)
	{
		this.questionText = questionText;
		this.answerIndex = answerIndex;
	}
}

class Question
{
	public static List<Pair> questions = new List<Pair>()
	{
		new Pair("Czy pytania będą łatwe", 0),
		new Pair("Czy lubisz wódę", 1),
	};
}


