using System;
using HitTheBall.GamePlay.HittableObjects;
using HitTheBall.Infrastructure;
using UnityEngine;
using Zenject;

namespace HitTheBall.GamePlay
{
    public class HitHandler:MonoBehaviour
    {
        [SerializeField] private float hitRadius = 1;
        [SerializeField] private float hitPower = 1;
        [SerializeField] private float hitCooldown = 3;
        private HittableObjectsManager _hittableObjectsManager;
        private IInputSystem _inputSystem;
        private float _currentHitCooldown = 0;
        
        [Inject]
        private void Init(HittableObjectsManager hittableObjectsManager, IInputSystem inputSystem)
        {
            _hittableObjectsManager = hittableObjectsManager;
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            _inputSystem.AddWorldClickListener(Hit);
        }

        private void Hit(Vector3 hitPosition)
        {
            if(_currentHitCooldown>0)
                return;
            var objectPosition = _hittableObjectsManager.CurrentHittableObject.GetPosition();
            if (Vector3.Distance(hitPosition, objectPosition) <= hitRadius)
            {
                var direction = (objectPosition - hitPosition).normalized;
                _hittableObjectsManager.CurrentHittableObject.Hit(direction, hitPower);
            }

            _currentHitCooldown = hitCooldown;
        }

        private void Update()
        {
            if(_currentHitCooldown>0)
                _currentHitCooldown-=Time.deltaTime;
        }

        private void OnDestroy()
        {
            _inputSystem.RemoveWorldClickListener(Hit);
        }
    }
}