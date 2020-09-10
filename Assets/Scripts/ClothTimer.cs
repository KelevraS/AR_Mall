using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothTimer : MonoBehaviour
{
    private Material mat;

    [SerializeField] private float speed;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        mat.SetFloat("_Timeposition", Mathf.PingPong(Time.time * speed, 1f));
    }
}
