using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform graphics;
    [SerializeField] private Rigidbody2D rigidbody2DPlayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootInterval;
    [SerializeField] private Bullet prefabBullet;
    
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private ObjectPoolMono<Bullet> objectPoolMono;

    private float shootTimer;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerMovement = new PlayerMovement(graphics, rigidbody2DPlayer, moveSpeed);
        objectPoolMono = new ObjectPoolMono<Bullet>(prefabBullet, 10);
    }

    private void Update()
    {
        playerInput.ReadValue();
        playerMovement.Move(playerInput.direction);
        Shoot();
    }

    private void FixedUpdate()
    {
        playerMovement.Move();
    }

    private void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0;
            var bullet = objectPoolMono.GetItem();
            var direction = Vector2.right; //TODO: temp solution;
            bullet.Initialized(transform.position);
            bullet.Move(direction);
        }
    }
}
