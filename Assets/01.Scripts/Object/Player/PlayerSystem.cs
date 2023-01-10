using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour, ISystem
{
	private Movement player;

	private void Awake()
	{
		player = GameObject.Find("Player").GetComponent<Movement>();
	}

	public void UpdateState(GameState state)
	{
		switch (state)
		{
			case GameState.Init:
			case GameState.Standby:
				player.Initialize();
				break;
			case GameState.Running:
				player.Active();
				break;
			case GameState.Result:
				player.Die();
				break;
		}
	}
}
