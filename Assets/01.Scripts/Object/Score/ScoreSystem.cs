using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour, ISystem
{
	public ScoreManager score;

	public void UpdateState(GameState state)
	{
		switch (state)
		{
			case GameState.Init:
			case GameState.Standby:
				score.Initialize();
				break;
			case GameState.Running:
				score.StartScoring();
				break;
			case GameState.Result:
				score.StopScoring();
				break;
		}
	}
}
