using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake: MonoBehaviour {

	public Snake next;
	private Vector2 position;
	static public Action<String> hit;

	public void SetNext(Snake next)
	{
		this.next = next;
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
