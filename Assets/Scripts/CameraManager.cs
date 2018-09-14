using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameViewType_2D
{
    TOP,
    SIDE,
    CUSTOM,
};
public enum GameViewType_3D
{
    TOP,
    SIDE,
    QUARTER,
    CUSTOM,
};

[ExecuteInEditMode]
public class CameraManager : SingleTon<CameraManager>
{
    public GameViewType_2D gameViewType_2D;
    public GameViewType_3D gameViewType_3D;

    private void Update()
    {
        
    }
}
