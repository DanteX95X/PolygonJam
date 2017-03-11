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
		new Pair("Czy po Szczecinie jeżdzą tramwaje", 1),
		new Pair("Czy angina jest zaraźliwa", 1),
		new Pair("Czy bataty się obiera", 1),
		new Pair("Czy mąka orkiszowa jest bezglutenowa", 0),
		new Pair("Czy viagra jest na receptę", 0),
		new Pair("Czy Xbox One ma Wi-Fi", 1),
		new Pair("Czy Y to samogłoska", 1),
		new Pair("Czy zęby mleczne mają korzenie", 0),
		new Pair("Czy węże potrafią chodzić", 0),
		new Pair("Czy źrenica to dziura", 1),
		new Pair("Czy czekolada pomaga na biegunkę", 1),
		new Pair("Czy cegła szamotowa trzyma ciepło", 1),
		new Pair("Czy podeszwa buta podlega reklamacji", 1),
		new Pair("Czy prostowanie keratynowe niszczy włosy", 1),
		new Pair("Czy cycki mają kości", 0),
	};
}


