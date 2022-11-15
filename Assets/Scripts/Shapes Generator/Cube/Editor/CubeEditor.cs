using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(CubeGenerator))]
public class CubeEditor : Editor
{

	public override void OnInspectorGUI()
	{
		CubeGenerator cubeGen = (CubeGenerator)target;
    if(DrawDefaultInspector())
		{
    }

		if(GUILayout.Button("Generate"))
		{
			cubeGen.Process();
		}
    }
}
