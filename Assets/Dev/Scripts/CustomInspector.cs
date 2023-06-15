using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GemFarmGenerator))]
public class CustomInspector : Editor
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
