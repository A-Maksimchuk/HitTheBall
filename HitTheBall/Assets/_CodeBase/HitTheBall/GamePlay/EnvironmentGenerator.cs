using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject backgroundPref;
    [SerializeField] private float zPosition = 10;
    [SerializeField] private float xDistance = 5;
    [SerializeField] private float yDistance = 100;
    [SerializeField] private float dencity = 1000;
    [SerializeField] private float maxScale = 10;

    async void Start()
    {
        for (int i = 0; i < dencity; i++)
        {
            var instance = Instantiate(backgroundPref, parent);
            instance.transform.position =
                new Vector3(Random.Range(-xDistance, xDistance), Random.Range(-20, yDistance), Random.Range(zPosition, 100));
            instance.transform.rotation = Random.rotation;
            instance.transform.localScale = Vector3.one*Random.Range(0, maxScale);
            if(i%100==0)
                await UniTask.Yield();
        }
    }
}
