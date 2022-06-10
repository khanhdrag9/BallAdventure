using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    [SerializeField] private Collider2D line;

    public void Pass()
    {
        line.enabled = false;
        GetComponent<Animator>().SetTrigger("Pass");
        foreach(var a in GetComponentsInChildren<Animator>())
            a.SetTrigger("Pass");
    }
}
