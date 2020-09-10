using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothSystem : MonoBehaviour
{
    private const float SHOULDER_LENGTH = 0.45f; 
    
    [SerializeField]
    private Toggle clothToggle, vatToggle;

    [SerializeField]
    private Slider clothSlider;
    
    [SerializeField]
    private CapsuleCollider shoulder;

    [SerializeField]
    private GameObject clothModel, bakedModel;

    [SerializeField] private GameObject shoulderPanel;
    
    void Start()
    {
        /*clothSlider = FindObjectOfType<Slider>();
        cloth = FindObjectOfType<Cloth>();
        shoulder = GameObject.FindWithTag("Shoulder")?.GetComponent<CapsuleCollider>();

        clothToggle.onValueChanged.AddListener(isOn => { cloth.enabled = isOn; });
        clothSlider.onValueChanged.AddListener(length => { shoulder.height = SHOULDER_LENGTH * length; });*/

        clothToggle.onValueChanged.AddListener(isOn => SwitchTarget(isOn, clothModel));
        clothToggle.onValueChanged.AddListener(isOn => SwitchTarget(isOn, shoulderPanel));
        vatToggle.onValueChanged.AddListener(isOn => SwitchTarget(isOn, bakedModel));
        clothSlider.onValueChanged.AddListener(length => { shoulder.height = SHOULDER_LENGTH * length; });
    }

    private void SwitchTarget(bool state, GameObject target)
    {
        target.SetActive(state);
    }
    
    
}
