using System.Collections.Generic;
using UnityEngine;

public class Patrones : MonoBehaviour
{
    public static Patrones Instance { get; private set; }
    public int Score { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject); 
            return; 
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount) => Score += amount;
}


public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 20;
    private readonly Queue<GameObject> pool = new();

    void Awake()
    {
        for (int i = 0; i < initialSize; i++) pool.Enqueue(CreateNew());
    }

    private GameObject CreateNew()
    {
        var go = Instantiate(prefab);
        go.SetActive(false);
        go.transform.SetParent(transform);
        return go;
    }

    public GameObject Get()
    {
        if (pool.Count == 0) pool.Enqueue(CreateNew());
        var go = pool.Dequeue();
        go.SetActive(true);
        return go;
    }

    public void Release(GameObject go)
    {
        go.SetActive(false);
        go.transform.SetParent(transform);
        pool.Enqueue(go);
    }
}