using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(h, 0, 0);
        transform.Translate(move * speed * Time.deltaTime);
    }
}

