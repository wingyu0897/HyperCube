using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : UIComponent
{
	[SerializeField]
	private Button restartButton;
	[SerializeField]
	private Button returnMenuButton;

	private GameOverUIShowing overUIShow;

	private void Awake()
	{
		overUIShow = GetComponent<GameOverUIShowing>();
		restartButton.onClick.AddListener(() => 
		{
			GameManager.Instance.UpdateStateFade(GameState.Standby, () => overUIShow.Init());
			overUIShow.InteractableFalse();
		});
		returnMenuButton.onClick.AddListener(() => 
		{
			GameManager.Instance.UpdateStateFade(GameState.Menu, () => overUIShow.Init());
			overUIShow.InteractableFalse();
		});
	}

	private void Start()
	{
		overUIShow.Init();
	}

	public override void UpdateUI()
	{
		overUIShow.StartShowUI();
	}
}
