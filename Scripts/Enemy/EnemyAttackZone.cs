using System.Collections;
using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private float _radiusCircle;
    [SerializeField] private LayerMask _objecktSelectionMask;
    [SerializeField] private AttackPoint _attackPoint;
    [SerializeField] private SpawnerBullet _spawnerBullet;

    private bool _isFire;
    private float _shotDelay;
    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    public float TargetPosition { get; private set; }
    public bool IsLocatedInTargetZone { get; private set; }

    private void Start()
    {
        _shotDelay = 0.8f;
        _wait = new WaitForSeconds(_shotDelay);
    }

    private void FixedUpdate()
    {
        FindInAttackRadius();
    }

    private void FindInAttackRadius()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(_attackPoint.transform.position, _radiusCircle, _objecktSelectionMask);

        if (hitPlayer != null)
        {
            TargetPosition = hitPlayer.transform.position.y;

            if (_isFire == false)
            {
               _isFire = true;

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine(DelayShot());
            }

            IsLocatedInTargetZone = true;
        }
        else
        {
            IsLocatedInTargetZone = false;
        }
    }

    private IEnumerator DelayShot()
    {
        _spawnerBullet.TakeShot();

        yield return _wait;

        _isFire = false;
    }
}