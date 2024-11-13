using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxrotationZ;
    [SerializeField] private float _minrotationZ;
    [SerializeField] private InputReader _inputReader;

    private Vector2 _startPosition;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    public event Action<bool> OnFalling;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxrotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minrotationZ);
    }

    private void OnEnable()
    {
        _inputReader.Jumped += SoarHigher;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= SoarHigher;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y < 0)
        {
            OnFalling?.Invoke(true);
        }
    }

    private void Update()
    {
        Fly();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }

    private void SoarHigher()
    {
        OnFalling?.Invoke(false);

        _rigidbody.velocity = new Vector2(_speed, _jumpForce);
        transform.rotation = _maxRotation;
    }

    private void Fly()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}