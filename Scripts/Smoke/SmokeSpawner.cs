using UnityEngine;

public class SmokeSpawner : Spawner<Smoke>
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.SmokeWasCreated += SmokeSpawn;
    }

    private void OnDisable()
    {
        _inputReader.SmokeWasCreated -= SmokeSpawn;
    }

    protected void SmokeSpawn()
    {
        Spawn(transform.position);
    }
}