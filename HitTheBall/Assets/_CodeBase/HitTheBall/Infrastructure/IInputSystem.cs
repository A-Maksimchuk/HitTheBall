using System;
using UnityEngine;

namespace HitTheBall.Infrastructure
{
    public interface IInputSystem
    {
        public Action<Vector3> OnClickWorld { get; set; }
        public void SetCurrentCamera(Camera camera);
    }
}