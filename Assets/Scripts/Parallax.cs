using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam = null;
    public float movementFactor = 1.0f;
    public bool verticalDisplacement = false;
    private float width = 0.0f;
    private float height = 0.0f;
    private Vector2 startPosition;

    void Awake() {
        if (cam == null) {
            cam = Camera.main;
        }

        startPosition = new Vector2(transform.position.x, transform.position.y);

        Vector3 size = GetComponent<SpriteRenderer>().bounds.size;
        width = size.x;
        height = size.y;
    }

    void Start()
    {
    }

    void Update()
    {
        float horizontalDist = cam.transform.position.x * movementFactor;

        if (horizontalDist >= width + transform.position.x) {
            transform.position += new Vector3(horizontalDist + width, 0.0f, 0.0f); 
        }
        if (horizontalDist >= width - transform.position.x) {
            transform.position -= new Vector3(horizontalDist + width, 0.0f, 0.0f); 
        }

        if (verticalDisplacement) {
            float verticalDist = cam.transform.position.y * movementFactor;

            if (verticalDist >= height + transform.position.y) {
                transform.position += new Vector3(0.0f, verticalDist + height, 0.0f); 
            }
            if (verticalDist >= height - transform.position.x) {
                transform.position -= new Vector3(0.0f, verticalDist + height, 0.0f); 
            }
        }
    }
}
