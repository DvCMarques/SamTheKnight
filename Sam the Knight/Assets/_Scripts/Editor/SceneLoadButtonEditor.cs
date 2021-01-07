using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(SceneLoadButton))]
public class SceneLoadButtonEditor :  ButtonEditor{

    public override void OnInspectorGUI() {
       
        SceneLoadButton targetButton = (SceneLoadButton)target;

        GUILayout.Label("Select a Scene to Load when clicked");
        targetButton.TargetSceneName = EditorGUILayout.TextField("Target Scene", targetButton.TargetSceneName);


        EditorGUILayout.Space();
        base.OnInspectorGUI();
    }

}