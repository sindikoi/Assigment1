using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 500f;
    private Vector2 direction;
    private float move;
    [SerializeField] float jump_force = 8f;
    [SerializeField] bool on_ground=true;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(rb==null)
        {
            Debug.LogError("RigitBody is missing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
       direction = new Vector2(move, 0);
        if(Input.GetButtonDown("Jump")&on_ground)
            {
            rb.AddForce(Vector2.up*jump_force, ForceMode2D.Impulse); 
            on_ground = false;
            }
     

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed * Time.deltaTime,rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            on_ground = true;
        }
    }
}
