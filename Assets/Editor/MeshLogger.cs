using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshLogger : MonoBehaviour
{
    private Mesh _mesh;
    
    public void LogInfo()
    {
        _mesh = GetComponent<MeshFilter>().sharedMesh;
        
    }
}

[CustomEditor(typeof(MeshLogger))]
public class MeshLoggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        MeshLogger meshLogger = target as MeshLogger;
        
        if (!meshLogger)
            return;

        if (GUILayout.Button("Update info"))
        {
            
        }
    }
}
