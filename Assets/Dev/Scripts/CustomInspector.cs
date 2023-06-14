using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GridGenerator))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridGenerator gridGenerator = (GridGenerator)target;
        if (GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGrid();
        }
    }
}
