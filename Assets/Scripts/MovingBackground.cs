using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f; // Скорость прокрутки
    [SerializeField] private Material _material;
    [SerializeField] bool _isYaxis = true;

    void Update()
    {
        float offset = Time.time * scrollSpeed; // Рассчитываем смещение на основе времени и скорости
        Vector2 offsetVector = new Vector2();
        if (_isYaxis)
        {
            offsetVector = new Vector2(0, offset);    
        }
        else
        {
            offsetVector = new Vector2(offset, 0); 
        }
        _material.mainTextureOffset = offsetVector; // Устанавливаем смещение материала
    }
}