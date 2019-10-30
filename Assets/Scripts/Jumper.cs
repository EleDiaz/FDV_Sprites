using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpForce = 2.0f;

    void OnTriggerEnter2D(Collider2D collider2D) {
        Rigidbody2D rb = collider2D.GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.AddForce(jumpForce * -transform.up, ForceMode2D.Impulse);
        }
    }
}
