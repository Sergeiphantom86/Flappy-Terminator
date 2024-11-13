using System.Collections;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private ScoreCounter  _scoreCounter;

    private int _minPositionY;
    private int _maxPositionY;

    protected override void Awake()
    {
        base.Awake();

        _minPositionY = -3;
        _maxPositionY = 0;
    }

    private IEnumerator Start()
    {
        int delay = 5;

        WaitForSeconds wait = new (delay);

        while (enabled)
        {
            ChooseRandomSpawnPoint();

            yield return wait;
        }
    }

    private void ChooseRandomSpawnPoint()
    {
        Enemy enemy = Spawn(GetSpawnPosition());
        _scoreCounter.Set(enemy);
    }

    private Vector2 GetSpawnPosition()
    {
        return new Vector2(
            transform.position.x + GetPosition(),
            transform.position.y - GetPosition(_minPositionY, _maxPositionY));
    }

    private float GetPosition(int minPosition = 10, float maxPosition = 20)
    {
        return Random.Range(minPosition, maxPosition);
    }
}