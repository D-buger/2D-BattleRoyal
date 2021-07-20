using System.Collections.Generic;
using UnityEngine;

public enum eMouse
{
    Nothing,
    Down,
    Drag,
    Up
}

[System.Serializable]
public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private CursorImage image;

    public Vector2 cursorPos;
    public eMouse mouseState;

    public void CursorAwake()
    {
        image.Awake();
    }

    public void CursorUpdate()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            Down();
        else if (Input.GetMouseButtonUp(0))
            Up();

        if (Input.GetMouseButton(0))
            Drag();
        else
            Nothing();
    }

    private void Nothing()
    {
        mouseState = eMouse.Nothing;
        StartCoroutine(image.Nothing());
    }

    private void Down()
    {
        mouseState = eMouse.Down;
    }

    private void Drag()
    {
        mouseState = eMouse.Drag;
        StartCoroutine(image.Click());
    }

    private void Up()
    {
        mouseState = eMouse.Up;
    }
}
