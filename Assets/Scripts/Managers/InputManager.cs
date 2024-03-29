using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static GameControls _gameControls;
    
    public static void Init(Characters myCharacter)
    {
        _gameControls = new GameControls();

        _gameControls.Permanent.Enable();

        _gameControls.Game.Movement.performed += ctx =>
        {
            myCharacter.SetMovementDirection(ctx.ReadValue<Vector3>());
        };

        _gameControls.Game.Jump.started += jup =>
        {
            myCharacter.Jump();
        };
    }

    public static void SetGameControls()
    {
        _gameControls.Game.Enable();
        _gameControls.UI.Disable();
    }

    public static void SetUIControls()
    {
        _gameControls.UI.Enable();
        _gameControls.Game.Disable();
    }
    
}