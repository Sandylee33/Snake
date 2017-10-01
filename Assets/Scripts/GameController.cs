using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int maxSize;
	public int currentSize;
	public int xBound;
	public int yBound;
	public int score;
	public GameObject foodPreab;
	public GameObject currentFood;
	public GameObject snakePrefab;
	public Snake head;
	public Snake tail;
	public Vector2 nextPos;
	public int direction;
	public Text scoreText;
	public float speed = 0.5f;

	void OnEnable()
	{
		Snake.hit += Hit;
	}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("TimerInvoke", 0, speed);
		FoodFunction ();
	}
	void OnDisable()
	{
		Snake.hit -= Hit;
	}
	// Update is called once per frame
	void Update () {
		ChangeDirection ();
	}

	void TimerInvoke()
	{
		
		Movement ();
		StartCoroutine (CheckVisible ());
		if (currentSize >= maxSize) {
			TailFunction ();
		} else {
			currentSize++;
		}

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

	void TailFunction()
	{
		Snake tempSnake = tail;
		tail = tail.GetNext ();
		tempSnake.RemoveTail ();
	}

	void FoodFunction()
	{
		int xPos = Random.Range (-xBound, xBound);
		int yPos = Random.Range (-yBound, yBound);
	
		currentFood = (GameObject)Instantiate (foodPreab, new Vector2 (xPos, yPos), transform.rotation);

		StartCoroutine (CheckRender (currentFood));
	}

	IEnumerator CheckRender(GameObject IN)
	{
		yield return new WaitForEndOfFrame ();
		if (IN.GetComponent<Renderer> ().isVisible == false) 
		{
			if (IN.tag == "food") 
			{
				Destroy (IN);
				FoodFunction ();
			}
		}
	}

	void Hit(string WhatWasSent)
	{
		if (WhatWasSent == "food") 
		{
			if (speed >= 0.1f) 
			{
				speed -= 0.05f;
				CancelInvoke ("TimerInvoke");
				InvokeRepeating ("TimerInvoke", 0, speed);
			}
			FoodFunction ();
			maxSize++;
			score++;
			scoreText.text = score.ToString ();
			int temp = PlayerPrefs.GetInt ("HighScore");
			if (score > temp) 
			{
				PlayerPrefs.SetInt ("HighScore", score);
			}
		}
		if (WhatWasSent == "snake") 
		{
			CancelInvoke ("TimerInvoke");
			Exit ();
		}
	}

	public void Exit()
	{
		SceneManager.LoadScene (0);

	}

	void Wrap()
	{
		if (direction == 0) 
		{
			head.transform.position = new Vector2 (head.transform.position.x, -(head.transform.position.y - 1));
		}
		else if (direction == 1) 
		{
			head.transform.position = new Vector2 (-(head.transform.position.x - 1), head.transform.position.y);
		}
		else if (direction == 2) 
		{
			head.transform.position = new Vector2 (head.transform.position.x, -(head.transform.position.y + 1));
		}
		else if (direction == 3) 
		{
			head.transform.position = new Vector2 (-(head.transform.position.x + 1), head.transform.position.y);
		}
	}

	IEnumerator CheckVisible()
	{
		yield return new WaitForEndOfFrame ();
		if (!head.GetComponent<Renderer> ().isVisible) 
		{
			Wrap ();
		}
	}

}
