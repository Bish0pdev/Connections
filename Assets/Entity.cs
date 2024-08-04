using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(SpriteRenderer))]
public class Entity : MonoBehaviour
{
    private SpriteRenderer _sr;

    public float radius = 1;
    public List<E_Connection> connections = new List<E_Connection>();

    public void On_Spawn(EntitySpawner spawner) {
        _sr = GetComponent<SpriteRenderer>();
        foreach(E_Connection connection in connections) {
            LineRenderer lr = new GameObject().AddComponent<LineRenderer>();
            lr.transform.parent = transform;
            lr.positionCount = 2;
            lr.SetPosition(0,connection.connection_one.transform.position);
            lr.SetPosition(1,connection.connection_two.transform.position);
            lr.widthMultiplier = spawner.connection_Width;
            lr.material = spawner.connection_Mat;
        }

        _sr.color = spawner.entity_Color;
    }

    public static Entity Create_New(EntitySpawner spawner, Vector2 position, float radius) {
        Entity newEntity = Instantiate(spawner.entity_Prefab).GetComponent<Entity>();
        newEntity.transform.position = position;
        newEntity.transform.localScale = new Vector3(1 * radius,1 * radius,0.1f);

        if(spawner.lastSpawnedEntity != null && spawner.lastSpawnedEntity != newEntity) {
            Connect(spawner.lastSpawnedEntity,newEntity);
        }

        newEntity.On_Spawn(spawner);
        return newEntity;
        
    }
    public static E_Connection Connect(Entity one, Entity two) {
        E_Connection newConnection = new E_Connection
        {
            connection_one = one,
            connection_two = two
        };

        one.connections.Add(newConnection);
        two.connections.Add(newConnection);

        return newConnection;
    }
}

[System.Serializable]
public struct E_Connection {
    public Entity connection_one;
    public Entity connection_two;
}