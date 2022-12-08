using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
	public Level prefab;
	public int count = 1;
}

[CreateAssetMenu(menuName = "SO/DATA/PoolLevelList")]
public class PoolLevelList : ScriptableObject
{
	public List<Pool> list = new List<Pool>();
}
