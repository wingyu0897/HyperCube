using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandbyUI : UIComponent
{
	[SerializeField]
	private Button runningTap;

	private void Start()
	{
		runningTap.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.Running));
	}

	public override void UpdateUI()
	{
		runningTap.gameObject.SetActive(true);
	}
}
