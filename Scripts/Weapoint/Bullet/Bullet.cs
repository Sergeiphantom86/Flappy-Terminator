using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 

public class Bullet : MonoBehaviour, IDestroyable<Bullet>
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rigidbody;

    public event Action<Bullet> Destroyed;

    public int Damage { get; private set; }

    private void Awake()
    {
        Damage = 50;
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    private IEnumerator Start()
    {
        float delay = 3f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;
        
        Destroyed?.Invoke(this);
    }

    private void Update()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    public void ResetComponentState()
    {
        gameObject.SetActive(false);
    }
}