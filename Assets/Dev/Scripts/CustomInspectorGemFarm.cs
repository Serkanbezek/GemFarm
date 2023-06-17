using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GemFarmGenerator))]
public class CustomInspectorGemFarm : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GemFarmGenerator gemFarmGenerator = (GemFarmGenerator)target;
        if (GUILayout.Button("Generate GemFarm"))
        {
            gemFarmGenerator.GenerateGemFarm();
        }
    }
}
