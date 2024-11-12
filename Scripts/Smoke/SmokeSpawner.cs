using UnityEngine;

public class SmokeSpawner : Spawner<Smoke>
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.SmokeWasCreated += Release;
    }

    private void OnDisable()
    {
        _inputReader.SmokeWasCreated -= Release;
    }

    protected void Release()
    {
        Spawn(transform.position);
    }
}