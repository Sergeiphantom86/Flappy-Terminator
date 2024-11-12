using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _minPositionX;
    [SerializeField] private int _maxPositionX;
    [SerializeField] private EnemyAttackZone _enemyAttackZone;

    private float _move;

    private void Awake()
    {
        _move = 1;
    }

    private void Update()
    {
        DetermineDirection();
    }

    private void Walk(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _move * Time.deltaTime);
    }

    private void DetermineDirection()
    {
        if (_enemyAttackZone.IsLocatedInTargetZone)
        {
            Walk(GetNewVector());
        }
    }

    private Vector2 GetNewVector()
    {
        return new Vector2(transform.position.x, _enemyAttackZone.TargetPosition);
    }
}