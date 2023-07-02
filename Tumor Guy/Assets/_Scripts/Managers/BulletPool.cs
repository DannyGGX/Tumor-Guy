using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    private List<GameObject> pooledBullets;
    private int amountOfBullets = 10;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        pooledBullets = new List<GameObject>();
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledBullets.Add(bullet);
        }
    }

    public GameObject GetBulletFromPool()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (pooledBullets[i].activeInHierarchy == false)
            {
                return pooledBullets[i];
            }
        }
        // If no inactive bullet found, then add a new bullet
        GameObject bullet = Instantiate(bulletPrefab);
        pooledBullets.Add(bullet);
        return bullet;
    }
}
