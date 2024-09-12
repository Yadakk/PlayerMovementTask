using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBootstrapper : MonoBehaviour
{
    private void Awake()
    {
        PlayerSetup();
    }

    private void PlayerSetup()
    {
        Player player = GetComponentInChildren<Player>();
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerInput.SetInvoker(new(player));
    }
}
