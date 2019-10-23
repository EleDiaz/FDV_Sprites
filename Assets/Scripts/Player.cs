using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam = null;
    public float movementSpeed = 1.0f;
    public float cameraMaxSeekDistance = .5f;
    private Animator animator;


    void Awake() {
        if (cam == null) {
            cam = Camera.main;
        }

        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(vertical + horizontal));
        
        // Character movement
        transform.position += 
            new Vector3(horizontal, vertical, 0.0f).normalized * movementSpeed * Time.deltaTime;

        Vector2 camPos = new Vector2(cam.transform.position.x, cam.transform.position.y);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 smoothedCameraPosition = 
            Vector2.Lerp(camPos, playerPos, 
                0.0525f
                //Mathf.Clamp(Vector2.Distance(camPos, playerPos) / cameraMaxSeekDistance, 0, 1)
            );

        cam.transform.position = 
            new Vector3(smoothedCameraPosition.x, smoothedCameraPosition.y, cam.transform.position.z);
    }
}
