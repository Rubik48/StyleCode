using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletPrefab;
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
            GameObject bullet = SpawnBullet(shootDirection);
            
            ConfigureBullet(bullet, shootDirection);
            
            yield return new WaitForSeconds(_shootingInterval);
        }
    }

    private GameObject SpawnBullet(Vector3 direction)
    {
        Vector3 spawnPosition = transform.position + direction;
        
        return Instantiate(_bulletPrefab, spawnPosition, Quaternion.identity);
    }

    private void ConfigureBullet(GameObject bullet, Vector3 direction)
    {
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        bulletRb.transform.up = direction;
        bulletRb.velocity = direction * _bulletSpeed;
    }
}