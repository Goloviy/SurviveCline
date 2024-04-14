using UnityEngine;

public class PlayerMovement : IMove
{
    private Transform graphics;
    private Rigidbody2D rigidbody2DPlayer;
    private float moveSpeed;
    
    private Vector2 direction;

    public PlayerMovement(Transform _graphics, Rigidbody2D _rigidbody2DPlayer, float _speed)
    {
        graphics = _graphics;
        rigidbody2DPlayer = _rigidbody2DPlayer;
        moveSpeed = _speed;
    }

    private void UpdateGraphics()
    {
        switch (direction.x)
        {
            case > 0:
                graphics.localScale = Vector3.one;
                break;
            case < 0:
                graphics.localScale = new Vector3(-1, 1, 1);
                break;
        }
    }

    public void Move()
    {
        rigidbody2DPlayer.MovePosition(rigidbody2DPlayer.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public void Move(Vector2 _direction)
    {
        direction = _direction;
        UpdateGraphics();
    }
}
