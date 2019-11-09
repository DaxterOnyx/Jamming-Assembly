using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBubble : MonoBehaviour
{
    public Vector3 gap;
    
    void Update()
    {
        transform.position = Input.mousePosition + gap;
    }
}
