using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerMoveType
{
    NONE,
    조이스틱,
    WASD_방향키,
};

public enum PlayerMoveDirectionType_Top
{
    NONE,
    방향_4,
    방향_8,
};

public class PlayerMove : MonoBehaviour
{
    public float playerMoveSpeed;
    public PlayerMoveType playerMoveType;
    public PlayerMoveDirectionType_Top playerMoveDirectionType;

    public Joystick joystick;
    private Vector3[] joystickDirection_4 =
        new[] { new Vector3(0, 1.0f), new Vector3(1.0f, 0), new Vector3(0, -1.0f), new Vector3(-1.0f, 0) };
    private Vector3[] joystickDirection_8 =
        new[] { new Vector3(0, 1.0f), new Vector3(0.7f, 0.7f), new Vector3(1.0f, 0), new Vector3(0.7f, -0.7f), new Vector3(0, -1.0f), new Vector3(-0.7f, -0.7f), new Vector3(-1.0f, 0), new Vector3(-0.7f, 0.7f), };
    private float[] joystickDistance_4 = new float[4];
    private float[] joystickDistance_8 = new float[8];

    public bool isAccel;

    private void Update()
    {
        if (GameManager.Instance.gameEnvironment == GameEnvironment._2D)
        {
            if (CameraManager.Instance.gameViewType_2D.Equals(GameViewType_2D.TOP))
            {
                if (playerMoveType == PlayerMoveType.WASD_방향키)
                {
                    float posX = 0, posY = 0;
                    Vector3 moveDirection = Vector3.zero;
                    if (playerMoveDirectionType == PlayerMoveDirectionType_Top.NONE)
                    {
                        posX = Input.GetAxis("Horizontal");
                        posY = Input.GetAxis("Vertical");

                        moveDirection = new Vector3(posX, posY).normalized;
                    }
                    else if (playerMoveDirectionType == PlayerMoveDirectionType_Top.방향_4)
                    {
                        posX = Input.GetAxisRaw("Horizontal");
                        posY = Input.GetAxisRaw("Vertical");

                        if (Mathf.Abs(posX) > Mathf.Abs(posY)) moveDirection = new Vector3(posX, 0).normalized;
                        else moveDirection = new Vector3(0, posY).normalized;
                    }
                    else if (playerMoveDirectionType == PlayerMoveDirectionType_Top.방향_8)
                    {
                        posX = Input.GetAxisRaw("Horizontal");
                        posY = Input.GetAxisRaw("Vertical");

                        moveDirection = new Vector3(posX, posY).normalized;
                    }
                    transform.Translate(moveDirection * Time.deltaTime);
                }
                else if (playerMoveType == PlayerMoveType.조이스틱)
                {
                    if (joystick == null) Debug.LogError("조이스틱을 넣어주세요~");

                    if (playerMoveDirectionType == PlayerMoveDirectionType_Top.NONE)
                    {
                        transform.Translate(joystick.normalizedTouchPos * Time.deltaTime);
                    }
                    else if (playerMoveDirectionType == PlayerMoveDirectionType_Top.방향_4 && joystick.normalizedTouchPos != Vector3.zero)
                    {
                        int num = 0;
                        float min;

                        for (int i = 0; i < joystickDirection_4.Length; i++)
                            joystickDistance_4[i] = Vector3.Distance(joystick.normalizedTouchPos, joystickDirection_4[i]);
                        min = joystickDistance_4[0];
                        for (int i = 1; i < joystickDistance_4.Length; i++)
                            if (min > joystickDistance_4[i])
                            {
                                min = joystickDistance_4[i];
                                num = i;
                            }

                        transform.Translate(joystickDirection_4[num] * Time.deltaTime);
                    }
                    else if (playerMoveDirectionType == PlayerMoveDirectionType_Top.방향_8 && joystick.normalizedTouchPos != Vector3.zero)
                    {
                        int num = 0;
                        float min;

                        for (int i = 0; i < joystickDirection_8.Length; i++)
                            joystickDistance_8[i] = Vector3.Distance(joystick.normalizedTouchPos, joystickDirection_8[i]);
                        min = joystickDistance_8[0];
                        for (int i = 1; i < joystickDistance_8.Length; i++)
                            if (min > joystickDistance_8[i])
                            {
                                min = joystickDistance_8[i];
                                num = i;
                            }

                        transform.Translate(joystickDirection_8[num] * Time.deltaTime);
                    }
                }
            }
            else if (CameraManager.Instance.gameViewType_2D.Equals(GameViewType_2D.SIDE))
            {
                if (playerMoveType == PlayerMoveType.WASD_방향키)
                {
                    transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0).normalized * Time.deltaTime);
                }
            }
        }

    }
}