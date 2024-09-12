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
        PlayerMovement.Move(_player.RigidBody, direction);
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
}
