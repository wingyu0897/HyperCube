using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyModeManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private Button easyButton;
    private RectTransform easyButtonRTrm;
    [SerializeField]
    private Image easyButtonImg;
    [SerializeField]
    private Button hardButton;
    private RectTransform hardButtonRTrm;
    [SerializeField]
    private Image hardButtonImg;

    [SerializeField]
    private Sprite easyUntoggleImage;
    [SerializeField]
    private Sprite easyToggleImage;
    [SerializeField]
    private Sprite hardUntoggleImage;
    [SerializeField]
    private Sprite hardToggleImage;

    [Space]
    [Header("Setting")]
    public float easyPlayerSpeed;
    public float easyPlayerSideSpeedMax;
    public float easyPlayerAcceleration;
    public float hardPlayerSpeed;
    public float hardPlayerSideSpeedMax;
    public float hardPlayerAcceleration;

    private Movement playerMovement;

	private void Start()
	{
		playerMovement = GameManager.Instance.GetSystem<PlayerSystem>().player;
		Init();
	}

	private void Init()
	{
        easyButton.onClick.AddListener(() => ChangeMode(true));
        hardButton.onClick.AddListener(() => ChangeMode(false));
        easyButtonRTrm = easyButtonImg.GetComponent<RectTransform>();
        hardButtonRTrm = hardButtonImg.GetComponent<RectTransform>();
        ChangeMode(true);
	}

	private void ChangeMode(bool diff)
	{
        SetButtonTransform(diff);

        playerMovement.ForwardSpeed = diff ? easyPlayerSpeed : hardPlayerSpeed;
        playerMovement.SidewardMaxSpeed = diff ? easyPlayerSideSpeedMax : hardPlayerSideSpeedMax;
        playerMovement.Acceleration = diff ? easyPlayerAcceleration : hardPlayerAcceleration;
	}

    private void SetButtonTransform(bool diff)
	{
        easyButtonImg.sprite = diff ? easyToggleImage : easyUntoggleImage;
        hardButtonImg.sprite = diff ? hardUntoggleImage : hardToggleImage;
        easyButtonRTrm.sizeDelta = diff ? new Vector2(200, 200) : new Vector2(180, 180);
        hardButtonRTrm.sizeDelta = diff ? new Vector2(180, 180) : new Vector2(200, 200);
    }
}
