using System;
using HitTheBall.SceneManagement;
using UnityEngine;
using Zenject;

namespace HitTheBall.Infrastructure
{
    public class InputSystem:MonoBehaviour, IInputSystem
    {
        private Action<Vector3> _onClickWorld;
        private Camera _currentCamera;

        private void Start()
        {
            if(_currentCamera==null)
                _currentCamera = Camera.main;
        }

        public void AddWorldClickListener(Action<Vector3> listener)
        {
            _onClickWorld += listener;
        }

        public void RemoveWorldClickListener(Action<Vector3> listener)
        {
            _onClickWorld -= listener;
        }

        public void SetCurrentCamera(Camera camera)
        {
            _currentCamera = camera;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 screenPosition = Input.mousePosition;
                screenPosition.z = -_currentCamera.transform.position.z;
                var worldPoint = _currentCamera.ScreenToWorldPoint(screenPosition);
                _onClickWorld?.Invoke(worldPoint);
            }
        }
    }
}