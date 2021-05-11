using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(MagnetTrap))]
public class DrawMagnetRange : Editor
{
    void OnSceneGUI()
    {
        MagnetTrap magnetTrap = (MagnetTrap)target;
        Handles.DrawWireArc(magnetTrap.transform.position, Vector3.up, Vector3.forward, 360, magnetTrap.radius);

    }

}
