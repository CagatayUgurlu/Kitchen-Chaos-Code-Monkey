using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {

        //Vector2 inputVector = new Vector2(0, 0);
        //playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        /*if (Input.GetKey(KeyCode.W))
          {
              inputVector.y = +1;
          }
          if (Input.GetKey(KeyCode.S))
          {
              inputVector.y = -1;
          }
          if (Input.GetKey(KeyCode.A))
          {
              inputVector.x = -1;
          }
          if (Input.GetKey(KeyCode.D))
          {
              inputVector.x = +1;
          }
          */

        Debug.Log(inputVector);

        inputVector = inputVector.normalized;// => PlayerInputActions => Processors => Vector2 Normalized.
        return inputVector;
    }
}
