﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public float speed;

    /// <summary>
    /// 1 - Make the object scrolling through the screen
    /// </summary>
    void Update()
    {
        Vector3 movement = new Vector3(
      speed * -1,
      0,
      0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}