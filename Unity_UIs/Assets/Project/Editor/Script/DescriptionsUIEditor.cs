using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(DescriptionsUI))]
public class DescriptionsUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var style = new GUIStyle(GUI.skin.button);

        DescriptionsUI targetObject = (DescriptionsUI)target;   

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.enabled = (targetObject.tmpObject == null) ? true : false;
        if (GUILayout.Button("initialize", style, GUILayout.Width(250), GUILayout.Height(25)))
        {

            GameObject textObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Project/Editor/Script/Text (TMP).prefab", typeof(GameObject));
            targetObject.Init(textObject);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}
