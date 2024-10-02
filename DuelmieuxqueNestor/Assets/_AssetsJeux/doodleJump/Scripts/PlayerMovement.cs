using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float PlayerSpeed = 2;

    [SerializeField]
    private Camscroll _camscroll;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x += h * PlayerSpeed * Time.deltaTime;
        transform.position = position;

        transform.position = _camscroll.cameraLimits.ClosestPoint(transform.position);
    }
}
