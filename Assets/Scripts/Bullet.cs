using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IMove
{
    [SerializeField] private Rigidbody2D rigidbody2DBullet;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    public void Initialized(Vector2 _startPosition)
    {
        transform.position = _startPosition;
    }
    
    public void Move(Vector2 _direction)
    {
        rigidbody2DBullet.velocity = _direction * speed;
    }
}
