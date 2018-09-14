using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEnvironment
{
    _2D,
    _3D,
};

public class GameManager : SingleTon<GameManager>
{
    public GameEnvironment gameEnvironment;
}
