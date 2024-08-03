using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float radius = 1;
    public List<E_Connection> connections = new List<E_Connection>();

    public static void Create_New(EntitySpawner spawner, Vector2 position, float radius) {
        Entity newEntity = Instantiate(spawner.entity_Prefab).GetComponent<Entity>();
        newEntity.transform.position = position;
        newEntity.transform.localScale = new Vector3(1 * radius,1 * radius,0.1f);
        
    }
}

public struct E_Connection {
    public Entity connection_one;
    public Entity connection_two;
}