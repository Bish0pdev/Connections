using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entity_Prefab;

    public Collider2D worldBounds;

    public int start_amount = 10;

    void Start()
    {
        for(int i = 0; i <= start_amount; i++) {
            
        }

    }
}
