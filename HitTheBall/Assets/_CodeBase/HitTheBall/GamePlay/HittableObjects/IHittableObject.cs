using UnityEngine;

namespace HitTheBall.GamePlay.HittableObjects
{
    public interface IHittableObject
    {
        public Vector3 GetPosition();
        public void Hit(Vector3 direction, float power);
    }
}