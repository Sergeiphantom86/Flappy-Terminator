using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpawnerBullet))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private SpawnerBullet _spawnerBullet;
    private float _shotDelay;
    private bool _isFire;
    private WaitForSeconds _wait;

   private void Awake()
    {
        _spawnerBullet = GetComponent<SpawnerBullet>();
        _shotDelay = 0.8f;
        _wait = new WaitForSeconds(_shotDelay);
    }

    private void OnEnable()
    {
        _inputReader.HeFired += TakeShot;
    }

    private void OnDisable()
    {
        _inputReader.HeFired -= TakeShot;
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
        _spawnerBullet.TakeShot();
    }

    private IEnumerator DelayShot()
    {
        Shoot();

        yield return _wait;

        _isFire = false;
    }
}