using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public GameObject ControlsStateDisplayer;

    private bool _playerControlsEnabled;
    public bool PlayerControlsEnabled
    {
        get => _playerControlsEnabled;
        set
        {
            if (value)
                _playerControls.Player.Enable();
            else
                _playerControls.Player.Disable();

            ControlsStateDisplayer.SetActive(!value);

            _playerControlsEnabled = value;
        }
    }

    private PlayerControls _playerControls;

    private PlayerInvoker _invoker;

    private bool _rotateFlag;

    private void Awake()
    {
        _playerControls = new();

        _playerControls.Player.OnJump.started += OnJumpHandler;
        _playerControls.Player.OnRotate.started += OnRotateHandler;
        _playerControls.Player.OnThrow.started += OnThrowHandler;
        _playerControls.Toggler.OnToggleControls.started += OnToggleControlsHandler;
        _playerControls.Toggler.OnLockCursor.started += OnLockCursorHandler;

        _playerControls.Toggler.Enable();
        PlayerControlsEnabled = true;
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
        if (!_rotateFlag)
        {
            _rotateFlag = true;
            return;
        }

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
        PlayerControlsEnabled = !PlayerControlsEnabled;
    }

    private void OnLockCursorHandler(InputAction.CallbackContext context)
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerControlsEnabled = true;
    }
}
