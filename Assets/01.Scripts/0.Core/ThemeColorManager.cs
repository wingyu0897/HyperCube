using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeColorManager : MonoBehaviour
{
	[Tooltip("좌측이 배경색, 우측이 UI색이 된다.")]
    public List<Gradient> colorThemes;

	[SerializeField]
	private Camera cam;
	[SerializeField]
	private List<Image> color1Images;
	[SerializeField]
	private List<Image> color2Images;
	[SerializeField]
	private List<TextMeshProUGUI> texts;

    public void SetColor()
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
}
