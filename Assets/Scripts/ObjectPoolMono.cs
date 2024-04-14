using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolMono<T> where T : MonoBehaviour
{
    private T item;
    private Transform container;
    private List<T> pool;

    public ObjectPoolMono(T _item, int _count, Transform _container)
    {
        item = _item;
        container = _container;
        CreatePool(_count);
    }

    public ObjectPoolMono(T _item, int _count)
    {
        item = _item;
        CreatePool(_count);
    }

    private void CreatePool(int _count)
    {
        pool = new List<T>();

        for (int i = 0; i < _count; i++)
        {
            CreateItem();
        }
    }

    private T CreateItem(bool _isActive = false)
    {
        var createdItem = Object.Instantiate(item, container);
        createdItem.gameObject.SetActive(_isActive);
        pool.Add(createdItem);
        return createdItem;
    }

    public T GetItem()
    {
        foreach (var item in pool)
        {
            if (!item.gameObject.activeSelf)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }

        return CreateItem(true);
    }

    public void Release(T _item)
    {
        _item.gameObject.SetActive(false);
    }
}
