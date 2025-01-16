using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _shootingInterval;

    private void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private IEnumerator ShootingRoutine()
    {
        while (enabled)
        {
            Vector3 shootDirection = (_target.position - transform.position).normalized;
            Bullet bullet = SpawnBullet(shootDirection);
            
            ConfigureBullet(bullet, shootDirection);
            
            yield return new WaitForSeconds(_shootingInterval);
        }
    }

    private Bullet SpawnBullet(Vector3 direction)
    {
        Vector3 spawnPosition = transform.position + direction;
        
        return Instantiate(_bulletPrefab, spawnPosition, Quaternion.identity);
    }

    private void ConfigureBullet(Bullet bullet, Vector3 direction)
    {
        bullet.SetMoveDirection(direction, _bulletSpeed);
    }
}