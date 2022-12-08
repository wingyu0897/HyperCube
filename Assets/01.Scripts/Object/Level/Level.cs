using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public int maxWeight = 0;
    public int weight;

    public bool canMove = true;
    public float lenght;

    protected virtual void Update()
	{
        if (canMove)
		{
            transform.position -= new Vector3(0, Time.deltaTime * speed);
		}
	}

    public abstract void Initialize();
    public abstract void OnSpawn();
}
