/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapEditor))]
public class MapeditorEditor : Editor
{


	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		MapEditor myScript = (MapEditor)target;

		if (GUILayout.Button("Load Map from File"))
		{
			myScript.LoadMap();
		}

		if (GUILayout.Button("Generate Map"))
		{
			myScript.GenerateMap();
		}
		if (GUILayout.Button("Delete Old Map"))
		{
			myScript.DeleteMap();
		}
	}
}
