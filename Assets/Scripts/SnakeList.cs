using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeList  {

	public Snake head;

	public SnakeList(Snake head)
	{
		this.head = head;
	}

	public void SetNext(Snake next)
	{
		var current = head;
		while (current.next != null) 
		{
			current = current.next;
		}
		current.next = next;
	}
	public Snake FindTail()
	{
		return head;
	}
}
