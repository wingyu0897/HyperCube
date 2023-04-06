using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour, ISystem
{
	public List<UIComponent> uiComponents = new List<UIComponent>();

	public void UpdateState(GameState state)
	{
		foreach (UIComponent uiComponent in uiComponents)
		{
			if (uiComponent.state == state)
			{
				uiComponent.UpdateUI();
			}
		}
	}
}
