using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject snakePrefab;
	public Snake head;
	public Snake tail;
	public Vector2 nextPos;
	public int direction;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("TimerInvoke", 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		ChangeDirection ();
	}

	void TimerInvoke()
	{
		Movement ();
	}

	void Movement()
	{
		GameObject temp;
		nextPos = head.transform.position;
		switch (direction) 
		{
		case 0:
			nextPos = new Vector2 (nextPos.x, nextPos.y + 1);
			break;
		case 1:
			nextPos = new Vector2 (nextPos.x + 1, nextPos.y);
			break;
		case 2:
			nextPos = new Vector2 (nextPos.x, nextPos.y - 1);
			break;
		case 3:nextPos = new Vector2 (nextPos.x - 1, nextPos.y);
			break;
		}
		temp = (GameObject)Instantiate (snakePrefab, nextPos, transform.rotation);
		head.SetNext (temp.GetComponent<Snake>(), nextPos);
		head = temp.GetComponent<Snake> ();
		return;
	}

	void ChangeDirection()
	{
		if (direction != 2 && Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			direction = 0;
		}
		if (direction != 3 && Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			direction = 1;
		}
		if (direction != 0 && Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			direction = 2;
		}
		if (direction != 1 && Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			direction = 3;
		}
	}


}
