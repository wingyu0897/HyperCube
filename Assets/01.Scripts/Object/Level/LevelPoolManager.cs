using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPoolManager : MonoBehaviour
{
	private Dictionary<string, LevelPool> pools = new Dictionary<string, LevelPool>();

	public void CreatePool(Level prefab, Transform parent, int count = 1)
	{
		LevelPool pool = new LevelPool(prefab, parent, count);
		pools.Add(prefab.gameObject.name, pool);
	}

	public Level Pop(Level level)
	{
		if (pools.ContainsKey(level.gameObject.name) == false)
		{
			Debug.LogError($"{level.gameObject.name}에 해당하는 풀이 존재하지 않음");
			return null;
		}

		Level obj = pools[level.gameObject.name].Pop();
		obj.Initialize();
		return obj;
	}

	public void Push(Level obj)
	{
		if (pools.ContainsKey(obj.gameObject.name))
		{
			pools[obj.gameObject.name].Push(obj);
		}
		else
		{
			Debug.LogError($"{obj.gameObject.name}에 해당하는 풀이 존재하지 않음");
		}
	}
}
