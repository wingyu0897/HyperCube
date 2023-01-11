using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkModeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject darkModeScreen;
    [SerializeField]
    private Button modeChangeButton;

	[SerializeField]
	private Sprite normalImage;
	[SerializeField]
	private Sprite darkImage;

    private bool isDarkMode;

	private void Awake()
	{
		Init();
	}

    private void Init()
	{
		ChangeMode(false);
		modeChangeButton.onClick.AddListener(ToggleMode);
	}

	public void ToggleMode()
	{
		ChangeMode(!isDarkMode);
	}

	private void ChangeMode(bool mode)
	{
		isDarkMode = mode;
		darkModeScreen.SetActive(isDarkMode);
		modeChangeButton.image.sprite = mode ? darkImage : normalImage;
	}
}
