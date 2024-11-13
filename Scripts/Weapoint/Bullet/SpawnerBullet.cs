using UnityEngine;

public class SpawnerBullet : Spawner<Bullet>
{
    [SerializeField] private FirePoint _firePoint;

    public void TakeShot()
    {
        Spawn(_firePoint.transform.position);
    }
}