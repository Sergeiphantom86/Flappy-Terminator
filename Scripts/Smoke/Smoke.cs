using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Smoke : MonoBehaviour, IDestroyable<Smoke>
{
    public event Action<Smoke> Destroyed;

    protected IEnumerator Start()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        yield return wait;

        Destroyed?.Invoke(this);
    }
}