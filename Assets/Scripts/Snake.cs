using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake: MonoBehaviour {

	private Snake next;
	private Vector2 position;
	static public Action<String> hit;

	public void SetNext(Snake nextSnake, Vector2 nextPos)
	{
		next = nextSnake;
		position = nextPos;
	}

	public Snake GetNext()
	{
		return next;
	}

	public Vector2 GetPos()
	{
		return position;
	}

	public void RemoveTail()
	{
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (hit != null) 
		{
			hit (other.tag);
		}
		if (other.tag == "food") 
		{
			Destroy (other.gameObject);
		}
	}
}
