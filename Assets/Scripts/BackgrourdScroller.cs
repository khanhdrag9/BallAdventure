using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrourdScroller : MonoBehaviour
{
    [SerializeField] private float minY;

    void Update()
    {
        if(transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, 0 + transform.position.y - minY, 0);
        }
    }
}
