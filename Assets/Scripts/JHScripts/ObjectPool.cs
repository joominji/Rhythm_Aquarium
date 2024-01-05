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
        else // ������ ������Ʈ ������ �ѱ�ٸ�
        {
            obj = objectPool.Dequeue(); // ���� ������ ������Ʈ�� ����
            obj.SetActive(false);

            //obj.transform.position = transform.position; // ��ġ �缳���� �ʿ��� ���
            obj.SetActive(true);
            objectPool.Enqueue(obj);
        }

        return obj;
    }
}
