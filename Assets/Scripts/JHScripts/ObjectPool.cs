using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int maxPoolSize;

    private Queue<GameObject> objectPool;

    private void Start()
    {
        objectPool = new Queue<GameObject>();
    }

    public GameObject GetObjectFromPool()
    {
        GameObject obj;

        if (objectPool.Count < maxPoolSize)
        {
            obj = Instantiate(prefab, transform);
            objectPool.Enqueue(obj);
        }
        else // 설정한 오브젝트 개수를 넘긴다면
        {
            obj = objectPool.Dequeue(); // 먼저 생성된 오브젝트를 뺀다
            obj.SetActive(false);

            //obj.transform.position = transform.position; // 위치 재설정이 필요할 경우
            obj.SetActive(true);
            objectPool.Enqueue(obj);
        }

        return obj;
    }
}
