using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScenarioController))]
public class ScenarioControllerEditor : Editor
{
    public bool test;

    public override void OnInspectorGUI()
    {
        ScenarioController scenarioController = (ScenarioController)target;
        DrawDefaultInspector();

        scenarioController.debugMode = EditorGUILayout.BeginToggleGroup("Debug Mode", scenarioController.debugMode);
        scenarioController.scenarioIsActive = EditorGUILayout.Toggle("Scenario is Active", scenarioController.scenarioIsActive);
        scenarioController.activeScenarioIndex = EditorGUILayout.IntField("Scenario Index", scenarioController.activeScenarioIndex);
        EditorGUILayout.EndToggleGroup();
    }
}
