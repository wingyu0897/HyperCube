using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeColorManager : MonoBehaviour, ISystem
{
	[Space]
	[SerializeField]
	private Camera cam;
	[Tooltip("맨좌측이 배경색, 맨우측이 UI색이 된다.")][Space]
    public List<Gradient> colorThemes;

	[SerializeField]
	private List<Image> color1Images;
	[SerializeField]
	private List<Image> color2Images;
	[SerializeField]
	private List<TextMeshProUGUI> texts;

    public void SetRandomColorTheme()
	{
		Gradient color = colorThemes[Random.Range(0, colorThemes.Count)];

		cam.backgroundColor = color.Evaluate(0);
		foreach (Image img in color1Images)
		{
			img.color = color.Evaluate(0f);
		}
		foreach (Image img in color2Images)
		{
			img.color = color.Evaluate(1f);
		}
		foreach (TextMeshProUGUI txt in texts)
		{
			txt.color = color.Evaluate(1f);
		}
	}

	public void UpdateState(GameState state)
	{
		switch (state)
		{
			case GameState.Init:
			case GameState.Standby:
				SetRandomColorTheme();
				break;
		}
	}
}
