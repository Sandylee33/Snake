using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake: MonoBehaviour {

	private Snake next;
	private Vector2 position;

	public void SetNext(Snake nextSnake, Vector2 nextPos)
	{
		next = nextSnake;
		position = nextPos;
	}

	public Snake GetNext()
	{
		return next;
	}

	public void RemoveTail()
	{
		Destroy (this.gameObject);
	}

}
