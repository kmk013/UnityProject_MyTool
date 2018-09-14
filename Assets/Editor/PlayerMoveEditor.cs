using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMove))]
public class PlayerMoveEditor : Editor
{
    PlayerMove playerMove;

    private void OnEnable()
    {
        playerMove = (PlayerMove)target;
    }

    public override void OnInspectorGUI()
    {
        playerMove.playerMoveSpeed = EditorGUILayout.Slider("이동속도", playerMove.playerMoveSpeed, 1, 100);

        EditorGUILayout.Space();
        playerMove.playerMoveType = (PlayerMoveType)EditorGUILayout.EnumPopup("이동방법", playerMove.playerMoveType);
        if (CameraManager.Instance.gameViewType_2D == GameViewType_2D.TOP || CameraManager.Instance.gameViewType_3D == GameViewType_3D.TOP)
            playerMove.playerMoveDirectionType = (PlayerMoveDirectionType_Top)EditorGUILayout.EnumPopup("이동방향", playerMove.playerMoveDirectionType);
        if (playerMove.playerMoveType == PlayerMoveType.조이스틱)
            playerMove.joystick = (Joystick)EditorGUILayout.ObjectField("조이스틱", playerMove.joystick, typeof(Joystick));
    }
}