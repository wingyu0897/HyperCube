using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelLevel : Level
{
	[SerializeField]
	private List<Transform> tunnels;
	[SerializeField][Range(0, 5f)]
	private float posXRandomness;

	public override void Initialize()
	{
		foreach (Transform tr in tunnels)
		{
			tr.position = new Vector3(0, tr.position.y);
		}
	}

	public override void OnSpawn()
	{
		if (tunnels.Count > 1)
		{
			tunnels[0].transform.position = new Vector3(0 + Random.Range(-posXRandomness, posXRandomness), tunnels[0].position.y);

			for (int i = 1; i < tunnels.Count; i++)
			{
				float random = Random.Range(-posXRandomness, posXRandomness);
				tunnels[i].transform.position = new Vector3(tunnels[i-1].position.x + random, tunnels[i].position.y);
			}
		}
	}
}
