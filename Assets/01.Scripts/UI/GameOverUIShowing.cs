using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
	private CanvasGroup overUI;

	private bool isOverUIActive = false;

	public void StartShowUI()
	{
		StopAllCoroutines();
		StartCoroutine(ShowUI());
	}

	public void Init()
	{
		StopAllCoroutines();
		isOverUIActive = false;
		fadeScreen.gameObject.SetActive(false);
		overUI.alpha = 0;
		overUI.interactable = false;
		overUI.blocksRaycasts = false;
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

			if (time >= curveTime * 0.5f && !isOverUIActive)
			{
				ActiveOverUI(true);
			}

			yield return new WaitForSeconds(Time.deltaTime);
		}
	}

	private void ActiveOverUI(bool active)
	{
		isOverUIActive = active;

		Tween to = DOTween.To(() => overUI.alpha, x => overUI.alpha = x, active ? 1f : 0, 1f);

		Sequence seq = DOTween.Sequence();
		seq.Append(to);
		seq.AppendCallback(() => { 
			overUI.interactable = active;
			overUI.blocksRaycasts = active;
			});
	}
}
