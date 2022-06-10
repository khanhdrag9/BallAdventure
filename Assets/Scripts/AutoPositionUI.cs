using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPositionUI : MonoBehaviour
{
    void Awake()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
