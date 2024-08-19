using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour, ISystem
{
	[SerializeField]
	private LevelManager levelManager;

	public void UpdateState(GameState state)
	{
		switch (state)
		{
			case GameState.Init:
			case GameState.Standby:
				levelManager.Initialize();
				break;
			case GameState.Running:
				levelManager.Active();
				break;
			case GameState.Result:
				levelManager.StopMove();
				break;
		}
	}
}
