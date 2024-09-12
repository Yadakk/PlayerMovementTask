using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoker
{
    private readonly Player _player;

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
        PlayerMovement.Rotate(_player.transform, delta);
    }

    public void Jump()
    {
        if (!_player.IsGrounded) return;
        PlayerMovement.Jump(_player.RigidBody, _player.JumpForce);
    }

    public void Throw()
    {
        GameObject throwable = Object.Instantiate(_player.Throwable, _player.ThrowableParent);
        GameObjectThrower.Throw(throwable.GetComponent<Rigidbody>(), Camera.main.transform.forward * _player.ThrowForce, _player.RigidBody);
    }
}
