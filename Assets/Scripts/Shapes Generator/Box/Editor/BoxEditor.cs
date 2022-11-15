using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(BoxGenerator))]
public class BoxEditor : Editor
{

	public override void OnInspectorGUI()
	{
		BoxGenerator boxGen = (BoxGenerator)target;
    if(DrawDefaultInspector())
		{
    }

		if(GUILayout.Button("Generate"))
		{
			boxGen.Process();
		}
    }
}
