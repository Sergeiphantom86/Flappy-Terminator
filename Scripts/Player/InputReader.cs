using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]

public class InputReader : MonoBehaviour
{
    private Weapon _weapon;
  
    public event Action SmokeWasCreated;
    public event Action Jumped;
    public event Action HeFired;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumped?.Invoke();
            SmokeWasCreated?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HeFired?.Invoke();
        }
    }
}