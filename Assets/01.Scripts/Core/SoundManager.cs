using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
	[SerializeField]
	private Button bgmButton;
	[SerializeField]
	private Sprite bgmOnImg;
	[SerializeField]
	private Sprite bgmOffImg;
	[SerializeField]
	private Button effectButton;
	[SerializeField]
	private Sprite effectOnImg;
	[SerializeField]
	private Sprite effectOffImg;
	[SerializeField]
	private AudioMixer mixer;

	private bool bgmActive = true;
	private bool effectActive = true;

	private void Start()
	{
		Init();
		bgmButton.onClick.AddListener(() => ToggleBGM());
		effectButton.onClick.AddListener(() => ToggleEffect());
	}

	private void Init()
	{
		mixer.SetFloat("BGMVolume", Mathf.Log10(1f) * 20);
		mixer.SetFloat("EffectVolume", Mathf.Log10(1f) * 20);
		bgmActive = true;
		effectActive = true;
	}

	public void ToggleBGM()
	{
		bgmActive = !bgmActive;
		mixer.SetFloat("BGMVolume", Mathf.Log10(bgmActive ? 1f : 0.001f) * 20);
		bgmButton.image.sprite = bgmActive ? bgmOnImg : bgmOffImg;
	}

	public void ToggleEffect()
	{
		effectActive = !effectActive;
		mixer.SetFloat("EffectVolume", Mathf.Log10(effectActive ? 1f : 0.001f) * 20);
		effectButton.image.sprite = effectActive ? effectOnImg : effectOffImg;
	}
}
