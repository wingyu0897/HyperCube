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
	private Material levelMaterial;
	[SerializeField]
	private float changingDuration;

	public void ChangeLevelColorSmooth()
	{
		Color levelColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f, 1f, 1f);

		DOTween.To(() => levelMaterial.GetColor("_Color"), x => levelMaterial.SetColor("_Color", x), levelColor, changingDuration);
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
