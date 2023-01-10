using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : UIComponent
{
	private GameOverUIShowing overUIShow;

	private void Awake()
	{
		overUIShow = GetComponent<GameOverUIShowing>();
	}

	public override void UpdateUI()
	{
		overUIShow.StartShowUI();
	}
}
