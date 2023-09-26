using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class InputManager
{
    private static Controls _controls;
    public static void Init(Player myPlayer)
    {
        _controls = new Controls();

        _controls.Game.Movement.performed += ctx =>
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        };

        _controls.Game.Jump.performed += ctx =>
        {
            myPlayer.SetJumpDirection(ctx.ReadValue<Vector2>());
        };

        _controls.Permanent.Enable();
    }
    public static void Gamemode()
    {
        _controls.Game.Enable();
        _controls.UI.Disable();
    }
    public static void UIMode()
    {
        _controls.Game.Disable();
        _controls.UI.Enable();
    }
}
