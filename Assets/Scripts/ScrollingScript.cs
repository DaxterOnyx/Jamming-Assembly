using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
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
