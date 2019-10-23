using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject player;
    public float distanceInteraction = 2.0f;
    public Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distanceInteraction) {
            animator.SetBool("OnMovement", true);
            animator.SetFloat("Horizontal", 1.0f);
        }   
        else {
            animator.SetFloat("Horizontal", 0.0f);
            animator.SetBool("OnMovement", false);
        }
    }
}
