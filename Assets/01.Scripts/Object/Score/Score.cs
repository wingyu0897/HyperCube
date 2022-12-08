using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI scoreText;

	public bool isOn = false;
	public float time = 0f;
	public int score;
	[Tooltip("스코어의 증가율, tim * increase")]
	public float increase = 1f;

	private void Update()
	{
		if (isOn)
		{
			time += Time.deltaTime;
			score = (int)Mathf.Floor(time * increase);
			scoreText.text = score.ToString();

			GameManager.instance.score = score;
		}
	}

	public void Initialize()
	{
		isOn = false;
		score = 0;
		scoreText.text = score.ToString();
	}

	public void StartScoring()
	{
		isOn = true;
		time = 0;
	}

	public void StopScoring()
	{
		isOn = false;
	}
}
