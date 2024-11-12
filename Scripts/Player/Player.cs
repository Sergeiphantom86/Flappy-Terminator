using System;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private PaintAttack _paintAttack;
    [SerializeField] private CollisionDetector _collisionDetector;

    private PlayerMover _playerMover;
    private Health _health;

    public event Action GameOver;

    private void Start()
    {
        _health = GetComponent<Health>();
        _playerMover = GetComponent<PlayerMover>(); 
    }

    private void OnEnable()
    {
        _collisionDetector.DeadlyCollide += FinishGame;
    }

    private void OnDisable()
    {
        _collisionDetector.DeadlyCollide -= FinishGame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            TakeDamage(bullet.Damage);
        }
    }

    public void Reset()
    {
        _playerMover.Reset();
        _health.RestoreHealth();
    }

    private void FinishGame()
    {
        GameOver?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _health.ApplyDamage(damage);
        _paintAttack.ChangeColor();

        if (_health.Amount <= 0)
        {
            FinishGame();
        }
    }
}