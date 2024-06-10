using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]

public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridGenerator gridGenerator = (GridGenerator)target;
        if (GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            gridGenerator.DestroyGrid();
        }
        if (GUILayout.Button("Assign Material"))
        {
            gridGenerator.AssignMaterial();
        }
    }

    [MenuItem("MamaMo/Generate Grid")]
    
    public static void GenerateGridMenu()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();
        if (gridGenerator != null)
        {
            gridGenerator.GenerateGrid();
        }
        else
        {
            Debug.LogError("No Grid Generator Found in Scene");
        }
    }
    [MenuItem("MamaMo/ClearGrid")]
    public static void ClearGridMenu()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();
        if (gridGenerator != null)
        {
            gridGenerator.DestroyGrid();
        }
        else
        {
            Debug.LogError("No Grid Generator Found in Scene");
        }
    }
}
