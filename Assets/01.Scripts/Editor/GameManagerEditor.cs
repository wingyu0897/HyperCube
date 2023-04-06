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
			(target as GameManager).UpdateState(GameState.Running);
		}
		if (GUILayout.Button("StopGame"))
		{
			(target as GameManager).UpdateState(GameState.Result);
		}
		if (GUILayout.Button("Initialize"))
		{
			(target as GameManager).UpdateState(GameState.Standby);
		}
	}
}
