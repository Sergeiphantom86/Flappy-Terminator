using UnityEngine;
using System.Collections;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private float _radiusCircle;
    [SerializeField] private LayerMask _objecktSelectionMask;
    [SerializeField] private AttackPoint _attackPoint;


    private Weapon _weapon;

    public float TargetPosition { get; private set; }
    public bool IsLocatedInTargetZone { get; private set; }

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
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

            _weapon.TakeShot();

            IsLocatedInTargetZone = true;
        }
        else
        {
            IsLocatedInTargetZone = false;
        }
    }
}