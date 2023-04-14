using System;
using System.Collections;
using System.Collections.Generic;
using HitTheBall.GamePlay.HittableObjects;
using UnityEngine;
using Zenject;

public class Trampline : MonoBehaviour
{
    [SerializeField] private float power;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Hittable"))
        {
            var hittableObject = other.gameObject.GetComponent<IHittableObject>();
            var currentVelocity = hittableObject.GetVelocity();
            hittableObject.Hit(currentVelocity.normalized,power);
        }
    }
}
