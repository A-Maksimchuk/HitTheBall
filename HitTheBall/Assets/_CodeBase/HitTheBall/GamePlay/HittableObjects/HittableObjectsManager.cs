using UnityEngine;

namespace HitTheBall.GamePlay.HittableObjects
{
    public class HittableObjectsManager : MonoBehaviour
    {
        [Header("IHittableObject script component is required")]
        [SerializeField] private GameObject startHittableObject;
        public IHittableObject CurrentHittableObject { get; private set; }

        private void Awake()
        {
            CurrentHittableObject = startHittableObject.GetComponent<IHittableObject>();
        }

        public void SetHittableObject(IHittableObject hittableObject)
        {
            CurrentHittableObject = hittableObject;
        }
    }
}
