using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
	public static CinemachineShake Instance;

    private CinemachineVirtualCamera cinemachineVCam;
	private float shakeTimer;
	private float shakeTimerTotal;
	private float startingIntensity;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		cinemachineVCam = GetComponent<CinemachineVirtualCamera>();
	}

	public void ShakeCamera(float intensity, float time)
	{
		CinemachineBasicMultiChannelPerlin cinemachinePerlin = cinemachineVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

		cinemachinePerlin.m_AmplitudeGain = intensity;
		startingIntensity = intensity;
		shakeTimerTotal = time;
		shakeTimer = time;
	}

	private void Update()
	{
		if (shakeTimer > 0)
		{
			shakeTimer -=  Time.deltaTime;
			if (shakeTimer <= 0f)
			{
				CinemachineBasicMultiChannelPerlin cinemachinePerlin = cinemachineVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
				cinemachinePerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
			}
		}
	}
}
