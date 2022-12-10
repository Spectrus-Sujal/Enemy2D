using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Enemy : MonoBehaviour
{
    
    // Enemy Stats
    [SerializeField] int health;
    [SerializeField] int speed;
    [SerializeField] int range;
    [SerializeField] int damage;


    [SerializeField] Transform player;

    void Start()
    {

    }

    void Update()
    {
        if (!InRange(player))
        {
            Move(player);
        }
        
    }

    private Vector2 GetPosition(Transform t)
    {
        return t.position;
    }

    
    private bool InRange(Transform target)
    {
        Vector2 start = GetPosition(this.transform);
        Vector2 end = GetPosition(target);
        return Vector2.Distance(start, end) < range;
    }
    

    private void Move(Transform goal)
    {
        Vector2 newPosition = GetPosition(transform);

        if (GetPosition(goal).x < newPosition.x)
        {
            newPosition.x -= Time.deltaTime * speed;
        }
        else
        {
            newPosition.x += Time.deltaTime * speed;
        }

        transform.position = newPosition;
    }

}
