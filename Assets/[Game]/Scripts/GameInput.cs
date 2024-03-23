using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        Instance = this;


        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
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
