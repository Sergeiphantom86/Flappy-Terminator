using System.Collections;
using UnityEngine;

public class Weapon : Spawner<Bullet>
{
    [SerializeField] private FirePoint _firePoint;

    private float _shotDelay;
    private bool _isFire;
    private WaitForSeconds _wait;

    protected override void Awake()
    {
        base.Awake();
        _shotDelay = 0.8f;
        _wait = new WaitForSeconds(_shotDelay);
    }

    public void TakeShot()
    {
        if (_isFire == false)
        {
            _isFire = true;
            StartCoroutine(DelayShot());
        }
    }

    private void Shoot()
    {
        Release();
    }

    private void Release()
    {
        Spawn(_firePoint.transform.position);
    }

    private Vector2 GetRotation(GameObject objectContainer)
    {
        return objectContainer.transform.rotation.eulerAngles;
    }

    private IEnumerator DelayShot()
    {
        Shoot();

        yield return _wait;

        _isFire = false;
    }
}