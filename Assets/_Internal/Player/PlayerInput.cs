using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls _playerControls;

    private PlayerInvoker _invoker;

    private void Awake()
    {
        _playerControls = new();

        _playerControls.Player.OnJump.started += OnJumpHandler;
        _playerControls.Player.OnRotate.started += OnRotateHandler;
        _playerControls.Player.OnThrow.started += OnThrowHandler;
        _playerControls.Toggler.OnToggleControls.started += OnToggleControlsHandler;
        _playerControls.Toggler.OnLockCursor.started += OnLockCursorHandler;

        _playerControls.Toggler.Enable();
    }

    private void OnEnable()
    {
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }

    private void FixedUpdate()
    {
        CallMovement();
    }

    private void CallMovement()
    {
        Vector2 direction = _playerControls.Player.OnMove.ReadValue<Vector2>();
        OnMoveHandler(direction);
    }

    public void SetInvoker(PlayerInvoker invoker)
    {
        _invoker = invoker;
    }

    private void OnMoveHandler(Vector2 direction)
    {
        _invoker.Move(direction);
    }

    private void OnRotateHandler(InputAction.CallbackContext context)
    {
        _invoker.Rotate(context.ReadValue<Vector2>());
    }

    private void OnJumpHandler(InputAction.CallbackContext context)
    {
        _invoker.Jump();
    }

    private void OnThrowHandler(InputAction.CallbackContext context)
    {
        _invoker.Throw();
    }

    private void OnToggleControlsHandler(InputAction.CallbackContext context)
    {
        enabled = !enabled;
    }

    private void OnLockCursorHandler(InputAction.CallbackContext context)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
