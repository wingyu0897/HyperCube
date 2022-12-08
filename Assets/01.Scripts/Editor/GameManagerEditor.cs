using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		if (GUILayout.Button("StartGame"))
		{
			(target as GameManager).StartGame();
		}
		if (GUILayout.Button("StopGame"))
		{
			(target as GameManager).StopGame();
		}
		if (GUILayout.Button("Initialize"))
		{
			(target as GameManager).InitializeGame();
		}
	}
}
