using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);//Sýraya sokmak için yaptýk..
        }
    }
    public GameObject GetPool()
    {
        GameObject obj = pooledObjects.Dequeue();//Sýradan çýkarmak için yaptýk
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);//Sýranýn sonuna ekliyoruz
        return obj;
    }

}
