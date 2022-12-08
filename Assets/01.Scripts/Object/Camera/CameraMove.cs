using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;
	[SerializeField]
	private Vector3 offset;

	private void LateUpdate()
	{
		transform.position = new Vector3(0, target.position.y, -10) + offset;
	}
}
