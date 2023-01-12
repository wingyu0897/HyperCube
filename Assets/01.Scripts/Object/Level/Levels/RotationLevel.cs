using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLevel : Level
{
	[SerializeField]
	private List<Transform> rotateObjects;
	[SerializeField]
	private float rotateSpeed = 1f;

	private void Update()
	{
		foreach (Transform tr in rotateObjects)
		{
			tr.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
		}
	}

	public override void Initialize()
	{
		foreach (Transform tr in rotateObjects)
		{
			tr.eulerAngles = Vector3.zero;
		}
	}

	public override void OnSpawn()
	{
		foreach (Transform tr in rotateObjects)
		{
			tr.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
		}
	}
}
