using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour 
{
    private Rigidbody _rigidbody;
    
    private void Awake() => _rigidbody = GetComponent<Rigidbody>();
    
    public void SetMoveDirection(Vector3 direction, float _bulletSpeed)
    {
     _rigidbody.transform.up = direction;
     _rigidbody.linearVelocity = direction * _bulletSpeed;
    }
}
