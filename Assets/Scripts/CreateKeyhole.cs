#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Keyhole))]
public class CreateKeyhole : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Keyhole keyhole = (Keyhole)target;
        if (GUILayout.Button("Create Keyhole"))
        {
            keyhole.CreateKeyhole();
        }
    }
}
#endif
