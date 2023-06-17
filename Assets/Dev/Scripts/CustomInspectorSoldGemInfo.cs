using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SoldGemInfoPanel))]
public class CustomInspectorSoldGemInfo : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SoldGemInfoPanel soldGemInfoPanel = (SoldGemInfoPanel)target;
        if (GUILayout.Button("Fill Panel Info"))
        {
            soldGemInfoPanel.FillPanelInfo();
        }
    }
}
