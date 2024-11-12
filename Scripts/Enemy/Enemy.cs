using System;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class Enemy : MonoBehaviour, IDestroyable<Enemy>
{
    private Health _health;
    [SerializeField] private DeathSmokeSpawner _smokeOfDeath;

    public event Action<Enemy> Destroyed;
    public event Action<Enemy> Died;

    private void Awake()
    {
        _health = GetComponent<Health>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            TakeDamage(bullet.Damage);
        }
    }

    public void TakeDamage(float damage)
    {
        _health.ApplyDamage(damage);

        if (_health.Amount <= 0)
        {
            Destroyed?.Invoke(this);

            Died.Invoke(this);

            _smokeOfDeath.Release(this);
        }
    }
}