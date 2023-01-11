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

	public bool isOn = false;
	public float time = 0f;
	public int score;
	[Tooltip("스코어의 증가율, tim * increase")]
	public float increase = 1f;

	private Color textOriginColor;

	private void Awake()
	{
		textOriginColor = scoreText.color;
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
				colorManager.ChangeBackgroundColorSmooth();
			}
		}
	}

	public void Initialize()
	{
		isOn = false;
		score = 0;
		scoreText.text = score.ToString();
		scoreText.color = textOriginColor;
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
	}
}
