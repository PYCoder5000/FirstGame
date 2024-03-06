using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    bool dragging = false;
    Vector3 offset;
    Vector3 currentMouse;
    Vector3 previousMouse;
    private void Update()
    {
        if (dragging)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            previousMouse = currentMouse;
            currentMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        Debug.DrawLine(transform.position, (currentMouse - previousMouse) * 500 + transform.position);
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
        GetComponent<Rigidbody2D>().velocity = (currentMouse - previousMouse) * 500;
    }
}
