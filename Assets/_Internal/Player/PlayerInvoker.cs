using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoker
{
    private readonly Player _player;

    private readonly LimitedRotation _limitedRotation = new();

    public PlayerInvoker(Player player)
    {
        _player = player;
    }

    public void Move(Vector2 direction)
    {
        PlayerMovement.Move(_player.RigidBody, direction * _player.MoveSpeed);
    }

    public void Rotate(Vector2 delta)
    {
        PlayerMovement.Rotate(_player.transform, delta * _player.Sensitivity, _limitedRotation);
    }

    public void Jump()
    {
        if (!_player.IsGrounded) return;
        PlayerMovement.Jump(_player.RigidBody, _player.JumpForce);
    }

    public void Throw()
    {
        Object.Instantiate(
            _player.BulletGameObject, 
            _player.transform.position, 
            Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, _player.transform.rotation.eulerAngles.y, 0f), 
            _player.BulletParent);
    }
}
