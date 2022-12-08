using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Movement player;
    public LevelManager lvManager;
	public Score scoreManager;

	public int score;

	public UnityEvent OnStart;
	public UnityEvent OnStop;
	public UnityEvent OnInitialize;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("다중 게임매니저 활성화");
		}
		else
		{
			instance = this;
		}
	}

	private void Start()
	{
		InitializeGame();
	}

	public void StartGame()
	{
		player?.Active();
		lvManager?.Active();
		scoreManager?.StartScoring();

		OnStart?.Invoke();
	}

	public void StopGame()
	{
		player?.Die();
		lvManager?.StopMove();
		scoreManager?.StopScoring();

		OnStop?.Invoke();
	}

	public void InitializeGame()
	{
		player?.Initialize();
		lvManager?.Initialize();
		scoreManager?.Initialize();

		OnInitialize?.Invoke();
	}
}
