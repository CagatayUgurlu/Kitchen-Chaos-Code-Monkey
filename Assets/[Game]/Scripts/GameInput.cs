using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        //Debug.Log(obj);
        /*if (OnInteractAction != null)
        {
            OnInteractAction(this, EventArgs.Empty); ==> Same as below
        }
        */
        OnInteractAction?.Invoke(this, EventArgs.Empty); 
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

        //Debug.Log(inputVector);

        inputVector = inputVector.normalized;// => PlayerInputActions => Processors => Vector2 Normalized.
        return inputVector;
    }
}
