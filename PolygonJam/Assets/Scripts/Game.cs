using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	Vector2 gridSize = new Vector2(0,0);

	[SerializeField]
	GameObject border = null;

	List<GameObject> borders = new List<GameObject>();

	void Start ()
	{
		borders.Add(Instantiate(border, new Vector3(0, Mathf.Ceil(gridSize.y/2), 0), transform.rotation) as GameObject);
		borders.Add(Instantiate(border, new Vector3(0, -Mathf.Ceil(gridSize.y/2), 0), transform.rotation) as GameObject);
		borders.Add(Instantiate(border, new Vector3(Mathf.Ceil(gridSize.x / 2), 0, 0), transform.rotation) as GameObject);
		borders.Add(Instantiate(border, new Vector3(-Mathf.Ceil(gridSize.x / 2), 0, 0), transform.rotation) as GameObject);

		for(int i = 0; i < borders.Count; ++i)
		{
			if(i < 2)
			{
				borders[i].transform.localScale = new Vector3(gridSize.x, 1, 1);
			}
			else
			{
				borders[i].transform.localScale = new Vector3(1, gridSize.y, 1);
			}
		}
	}
	
	void Update ()
	{
		
	}
}
