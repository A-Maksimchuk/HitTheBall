using UnityEngine;

namespace HitTheBall.GamePlay.HittableObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class SoccerBall:MonoBehaviour,IHittableObject
    {
        [SerializeField] public float hitPowerMultiplier = 1;
        private Transform _transform;
        private Rigidbody _rigidbody;

        void Start()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public Vector3 GetPosition()
        {
            return _transform.position;
        }

        public void Hit(Vector3 direction, float power)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction*power*hitPowerMultiplier);
        }

        public Vector3 GetVelocity()
        {
            return _rigidbody.velocity;
        }
    }
}