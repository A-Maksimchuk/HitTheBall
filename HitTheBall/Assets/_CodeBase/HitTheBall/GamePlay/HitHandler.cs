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
        private HittableObjectsManager _hittableObjectsManager;
        private IInputSystem _inputSystem;
        
        [Inject]
        private void Init(HittableObjectsManager hittableObjectsManager, IInputSystem inputSystem)
        {
            _hittableObjectsManager = hittableObjectsManager;
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            _inputSystem.OnClickWorld += Hit;
        }

        private void Hit(Vector3 hitPosition)
        {
            var objectPosition = _hittableObjectsManager.CurrentHittableObject.GetPosition();
            if (Vector3.Distance(hitPosition, objectPosition) <= hitRadius)
            {
                var direction = (objectPosition - hitPosition).normalized;
                _hittableObjectsManager.CurrentHittableObject.Hit(direction, hitPower);
            }
        }
    }
}