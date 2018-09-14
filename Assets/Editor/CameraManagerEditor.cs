using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniRx;

[CustomEditor(typeof(CameraManager))]
public class CameraManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GameManager.Instance.gameEnvironment == GameEnvironment._2D)
            CameraManager.Instance.gameViewType_2D = (GameViewType_2D)EditorGUILayout.EnumPopup("2D게임뷰 타입", CameraManager.Instance.gameViewType_2D);
        else if (GameManager.Instance.gameEnvironment == GameEnvironment._3D)
            CameraManager.Instance.gameViewType_3D = (GameViewType_3D)EditorGUILayout.EnumPopup("3D게임뷰 타입", CameraManager.Instance.gameViewType_3D);
    }
}