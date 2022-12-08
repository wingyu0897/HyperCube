using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPool
{
	public Level prefab;
	private Transform parent;
	public Stack<Level> pool = new Stack<Level>();

    public LevelPool(Level prefab, Transform parent, int count = 1)
	{
		this.prefab = prefab;
		this.parent = parent;

		for (int i = 0; i < count; i++)
		{
			Level obj = GameObject.Instantiate(prefab, parent);
			obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
			obj.gameObject.SetActive(false);
			pool.Push(obj);
		}
	}

	public void Push(Level obj)
	{
		obj.gameObject.SetActive(false);
		pool.Push(obj);
	}

	public Level Pop()
	{
		Level obj = null;

		if (pool.Count > 0)
		{
			obj = pool.Pop();
		}
		else
		{
			obj = GameObject.Instantiate(prefab, parent);
		}
		obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
		obj.gameObject.SetActive(true);
		return obj;
	}
}
