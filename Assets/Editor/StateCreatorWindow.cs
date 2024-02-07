using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class StateCreator : EditorWindow
{
    [MenuItem("Tools/StateCreator")]
    public static void ShowEditor()
    {
        //Method called when selected in Unity
        EditorWindow win = GetWindow<StateCreator>();
        win.titleContent = new GUIContent("State Creator");
    }

    public void CreateGUI()
    {
        rootVisualElement.Add(new Label("Work In Progress, will be done when it is too late to matter."));
    }
}