using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(ArenaPath))]
public class ArenaPathEditor : Editor
{
    private ArenaPath arenaPath = null;
    private Transform handleTransform = null;
    private Quaternion handleRotation = default;

    private void OnSceneGUI()
    {
        arenaPath = target as ArenaPath;
        handleTransform = arenaPath.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        Vector3[] points = arenaPath.Points;

        for (int i = points.Length - 1; i >= 0; i--)
        {
            ShowPoint(i);
        }

        for (int i = points.Length - 1; i >= 1; i--)
        {
            Handles.color = Color.red;
            Handles.DrawLine(points[i - 1], points[i]);
        }
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        if (!arenaPath.Settings)
        {
            EditorGUILayout.HelpBox("You must add settings", MessageType.Warning);
            return;
        }

        if (arenaPath.Points.Length > 2)
        {
            Debug.LogError("In this Object you not allowable to add more than two points");
            RepairPoints();
            return;
        }

        CheckStartEndPosition(arenaPath.Points);
    }

    private Vector3 ShowPoint(int index)
    {
        Vector3 point = arenaPath.Points[index];

        EditorGUI.BeginChangeCheck();

        point = Handles.DoPositionHandle(point, handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(arenaPath, "Move Point");
            EditorUtility.SetDirty(arenaPath);
            arenaPath.Points[index] = point;
        }
        return point;
    }

    private void CheckStartEndPosition(Vector3[] points)
    {
        if(points[0].x > points[1].x)
        {
            EditorGUILayout.HelpBox("At the Run time index will be swap because index 0 x Position is > to index 1 x Position", MessageType.Warning);
        }
    }

    private void RepairPoints ()
    {
        Vector3[] lastPoints = new Vector3[2];
        lastPoints[0] = arenaPath.Points[0];
        lastPoints[1] = arenaPath.Points[1];
        arenaPath.Points = new Vector3[2];
        arenaPath.Points[0] = lastPoints[0];
        arenaPath.Points[1] = lastPoints[1];
    }
}
#endif
