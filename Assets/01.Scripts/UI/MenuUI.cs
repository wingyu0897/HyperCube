using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIComponent
{
	[SerializeField]
	private CanvasGroup menuGroup;
	[SerializeField]
	private Button startButton;

	[SerializeField]
	private Button bgmToggleButton;
	[SerializeField]
	private Button effectToggleButton;

	private void Awake()
	{
		startButton.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.Standby));
		startButton.onClick.AddListener(() => SetActiveMenuUI(false));
	}

	private void SetActiveMenuUI(bool value)
	{
		menuGroup.interactable = value;
		menuGroup.blocksRaycasts = value;
		menuGroup.alpha = value ? 1f : 0;
	}

	public override void UpdateUI()
	{
		SetActiveMenuUI(true);
	}
}
