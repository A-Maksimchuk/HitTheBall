using System;
using UnityEngine;

namespace HitTheBall.Infrastructure
{
    public class InputSystem:MonoBehaviour, IInputSystem
    {
        public Action<Vector3> OnClickWorld { get; set; }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                OnClickWorld?.Invoke(new Vector3());
            }
        }
    }
}