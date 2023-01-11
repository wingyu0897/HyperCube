using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ThemeColorManager : MonoBehaviour, ISystem
{
	[Space]
	[SerializeField]
	private Camera cam;
	[Space]
	[SerializeField]
	private Material levelMaterial;
	[Tooltip("맨좌측이 배경색, 맨우측이 UI색이 된다.")]
    public List<Gradient> colorThemes;

	[SerializeField]
	private List<Image> color1Images;
	[SerializeField]
	private List<Image> color2Images;
	[SerializeField]
	private List<TextMeshProUGUI> texts;

	private Gradient lastColor;

	private void Start()
	{
		lastColor = null;
	}

	public void SetRandomColorTheme()
	{
		Gradient color = colorThemes[Random.Range(0, colorThemes.Count)];
		lastColor = color;

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

	public void ChangeLevelColorSmooth()
	{
		Gradient color;

		//do
		//{
		color = colorThemes[Random.Range(0, colorThemes.Count)];
		//} while (lastColor.Equals(color));

		Color levelColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f, 1f, 1f);

		lastColor = color;

		DOTween.To(() => levelMaterial.GetColor("_Color"), x => levelMaterial.SetColor("_Color", x), levelColor, 1f);
		//foreach (Image img in color2Images)
		//{
		//	DOTween.To(() => img.color, x => img.color = x, color.Evaluate(1f), 1f);
		//}
	}

	public void UpdateState(GameState state)
	{
		switch (state)
		{
			case GameState.Init:
			case GameState.Standby:
				levelMaterial.SetColor("_Color", Color.white);
				break;
		}
	}
}
