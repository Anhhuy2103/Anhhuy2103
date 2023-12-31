using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BayquaBaylai : MonoBehaviour
{
    
    [SerializeField] Transform[] position;
    public int speed;
    int nexPosIndex;

    Transform NextPos;

    public void Start()
    {
        NextPos = position[0];
    }

    public void Update()
    {
        bayquaBaylai();
    }
    public void bayquaBaylai()
    {
        if (transform.position == NextPos.position)
        {
            nexPosIndex++;
            if (nexPosIndex >= position.Length)
            {
                nexPosIndex = 0;
            }
            NextPos = position[nexPosIndex];

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    } 
}
