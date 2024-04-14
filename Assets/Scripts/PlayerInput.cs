using UnityEngine;

public class PlayerInput 
{
    //[SerializeField] private PlayerMovement playerMovement;
    private GameInput gameInput;
    public Vector2 direction { get; private set; }


    public PlayerInput()
    {
        gameInput = new GameInput();
        gameInput.Enable();
    }
    
    public void ReadValue()
    {
        direction = gameInput.Payer.Movement.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        gameInput.Enable();
    }

    private void OnDisable()
    {
        gameInput.Disable();
    }
}
