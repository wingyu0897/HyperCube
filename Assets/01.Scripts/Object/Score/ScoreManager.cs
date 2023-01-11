using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	private ThemeColorManager colorManager;

	[SerializeField]
	private TextMeshProUGUI scoreText;
	[SerializeField]
	private TextMeshProUGUI bestScoreText;
	[SerializeField]
	private GameObject newBestScoreText;

	public bool isOn = false;
	public float time = 0f;
	public int score;
	[Tooltip("스코어의 증가율, tim * increase")]
	public float increase = 1f;

	private int bestScore;

	private Color textOriginColor;

	private void Awake()
	{
		textOriginColor = scoreText.color;
		bestScore = PlayerPrefs.GetInt("BestScore", 0);
	}

	private void Update()
	{
		if (isOn)
		{
			time += Time.deltaTime;
			ChangeScore((int)Mathf.Floor(time * increase));
			scoreText.text = score.ToString();

			GameManager.Instance.score = score;
		}
	}

	private void ChangeScore(int scoreInput)
	{
		if (score != scoreInput)
		{
			score = scoreInput;
			if (score % 10 == 0)
			{
				colorManager.ChangeLevelColorSmooth();
			}
		}
	}

	public void Initialize()
	{
		newBestScoreText.SetActive(false);
		isOn = false;
		score = 0;
		scoreText.color = textOriginColor;
		scoreText.text = score.ToString();
		bestScoreText.text = bestScore.ToString();
	}

	public void StartScoring()
	{
		isOn = true;
		time = 0;
	}

	public void StopScoring()
	{
		isOn = false;
		scoreText.color = new Color(textOriginColor.r, textOriginColor.g, textOriginColor.b, 1f);

		if (score > bestScore)
		{
			newBestScoreText.SetActive(true);
			bestScore = score;
			PlayerPrefs.SetInt("BestScore", bestScore);
			bestScoreText.text = bestScore.ToString();
		}
	}
}
