using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScenarioController))]

/// <summary>
/// Used to customize ScenarioController component in Editor. 
/// Adds debug mode in Editor as a toggle group (makes group only available if debug mode is active)
/// 
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class ScenarioControllerEditor : Editor
{
    public bool test;

    public override void OnInspectorGUI()
    {
        ScenarioController sc = (ScenarioController)target;
        DrawDefaultInspector();

        sc.debugMode = EditorGUILayout.BeginToggleGroup("Debug Mode", sc.debugMode);
        sc.scenarioIsActive = EditorGUILayout.Toggle("Scenario is Active", sc.scenarioIsActive);
        sc.activeScenarioIndex = EditorGUILayout.IntField("Scenario Index", sc.activeScenarioIndex);
        EditorGUILayout.EndToggleGroup();
    }
}