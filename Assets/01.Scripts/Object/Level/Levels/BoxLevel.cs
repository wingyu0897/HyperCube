using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLevel : Level
{
	[SerializeField]
	private List<Transform> boxes;
	[SerializeField][Range(0, 10f)]
	private float posXRandomness = 0;

	public override void Initialize()
	{
		foreach (Transform tr in boxes)
		{
			tr.position = new Vector3(0, tr.position.y);
		}
	}

	public override void OnSpawn()
	{
		foreach (Transform tr in boxes)
		{
			tr.position = new Vector3(Random.Range(-posXRandomness, posXRandomness), tr.position.y);
		}
	}
}
