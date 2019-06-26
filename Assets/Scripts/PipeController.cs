using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float upDownSpeed;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("SwitchUpDown", 0.1f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwitchUpDown()
    {
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2(-speed, upDownSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PipeDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
