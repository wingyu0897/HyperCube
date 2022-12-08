using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueSnap : MonoBehaviour
{
    private Slider sliderUI;
	[SerializeField]
	private float snapInterval = 1f;

	private void Awake()
	{
		sliderUI = GetComponent<Slider>();
	}

	private void Start()
	{
		sliderUI.onValueChanged.AddListener(delegate { ShowSliderValue(); });
	}

	public void ShowSliderValue()
	{
		float value = sliderUI.value;
		value = Mathf.Round(value / snapInterval) * snapInterval;
		sliderUI.value = value;
	}
}
