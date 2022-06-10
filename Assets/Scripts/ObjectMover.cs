using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] public bool IsMoving = false;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(IsMoving)
        {
            float speed = Level.ObjectSpeed;
            float dt = Global.DeltaTime;
            
            transform.position = transform.position + Vector3.down * speed * dt;;
        }
    }
}
