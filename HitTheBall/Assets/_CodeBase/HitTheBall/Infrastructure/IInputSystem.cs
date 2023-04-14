using System;
using UnityEngine;

namespace HitTheBall.Infrastructure
{
    public interface IInputSystem
    {
        public void AddWorldClickListener(Action<Vector3> listener);
        public void RemoveWorldClickListener(Action<Vector3> listener);
        public void SetCurrentCamera(Camera camera);
    }
}