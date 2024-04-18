using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraControlTrigger))]
public class CameraControlEditor : Editor
{
    private CameraControlTrigger _trigger;

    private void OnEnable()
    {
        _trigger = (CameraControlTrigger)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CustomInspectorObj inspectorObj = _trigger.inspectorObj;
        if(inspectorObj.swapCamera)
        {
            inspectorObj.cameraOnLeft = EditorGUILayout.ObjectField("Camera On Left", inspectorObj.cameraOnLeft, typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
            inspectorObj.cameraOnRight = EditorGUILayout.ObjectField("Camera On Right", inspectorObj.cameraOnRight, typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;

        }

        if(inspectorObj.panCameraOnContact)
        {
            inspectorObj.panDirection = (PanDirection)EditorGUILayout.EnumPopup("Camera Moving Direction", inspectorObj.panDirection);
            inspectorObj.panDistance = EditorGUILayout.FloatField("Pan Distance", inspectorObj.panDistance);
            inspectorObj.panTime = EditorGUILayout.FloatField("Pan Time", inspectorObj.panTime);
        }

        if(GUI.changed) 
        {
            EditorUtility.SetDirty(_trigger);
        }
    }
}
