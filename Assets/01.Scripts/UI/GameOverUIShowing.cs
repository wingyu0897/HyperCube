using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIShowing : MonoBehaviour
{
	[Header("<Param>")]
	[SerializeField]
	private float showDelay = 2f;
	[SerializeField]
	private AnimationCurve fadeCurve;

	[Header("<Reference>")]
	[SerializeField]
	private Image fadeScreen;
	[SerializeField]
	private GameObject overUI;

	public void StartShowUI()
	{
		StopAllCoroutines();
		StartCoroutine(ShowUI());
	}

	IEnumerator ShowUI()
	{
		yield return new WaitForSeconds(showDelay);

		float time = 0;
		float curveTime = fadeCurve[fadeCurve.length - 1].time;

		fadeScreen.gameObject.SetActive(true);

		while (time <= curveTime)
		{
			fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, fadeCurve.Evaluate(time));

			time += Time.deltaTime;

			if (time >= curveTime * 0.5f)
			{
				overUI.SetActive(true);
				break;
			}

			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
