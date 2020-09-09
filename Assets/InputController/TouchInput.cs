using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 startPoint;
    private Vector2 currentPoint;
    private Vector3 direction = Vector3.zero;
    private IInput input;
    private Transform _transform;

    private void Start()
    {
        input = new MouseController();
        _transform = transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = input.GetPosition();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    private void Update()
    {
        currentPoint = input.GetPosition();
        var normalizedDir = currentPoint - startPoint;
        direction.Set(normalizedDir.x, 0f, normalizedDir.y);
        MovePlayer(direction);
    }

    private void MovePlayer(Vector3 dir)
    {
        _transform.position = dir;
    }
}

public class KeyboardController : IInput
{
    public Vector2 GetPosition()
    {
        throw new NotImplementedException();
    }
}

public class MouseController : IInput
{
    public Vector2 GetPosition()
    {
        return Input.mousePosition;
    }
}

public class TouchController : IInput
{
    public Vector2 GetPosition()
    {
        throw new NotImplementedException();
    }
}

interface IInput
{
    Vector2 GetPosition();
}
