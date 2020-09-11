using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothTimer : MonoBehaviour
{
    private Material mat;

    [SerializeField] private float speed = 2f;
    [SerializeField] private Animator anim;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        anim.speed = speed;
    }

    private void Update()
    {
        float normalizedTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        float animationSpeedMultiplier = anim.GetCurrentAnimatorStateInfo(0).speed;
        
        mat.SetFloat("_Timeposition", animationSpeedMultiplier > 0 ? normalizedTime : 1  - normalizedTime);
        
        Debug.LogFormat("Normalized time: {0} \n Speed multiplier: {1}", normalizedTime, animationSpeedMultiplier);
    }
}
