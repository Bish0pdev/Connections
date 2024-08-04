using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entity_Prefab;

    public Vector2 worldBoundSize;

    public Color entity_Color;

    public float connection_Width = 0.2f;
    public Material connection_Mat;

    public int start_amount = 10;

    public AnimationCurve size_Probability_Curve;

    public Entity lastSpawnedEntity { get; private set; }

    void Awake()
    {
        for(int i = 0; i <= start_amount; i++) {
            Vector3 newPos = new Vector3(Random.Range(-worldBoundSize.x, worldBoundSize.x),Random.Range(-worldBoundSize.y,worldBoundSize.y));

            float size = size_Probability_Curve.Evaluate(Random.value * size_Probability_Curve[size_Probability_Curve.length-1].value);

            lastSpawnedEntity = Entity.Create_New(this,newPos, size);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(worldBoundSize.x*2,worldBoundSize.y*2, 0.1f));
    }
}
