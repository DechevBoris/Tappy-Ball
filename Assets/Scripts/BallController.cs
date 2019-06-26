using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    public float upForce;
    Rigidbody2D rb;
    private bool started;
    private bool gameOver;
    public float rotationAmount;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
                GameManager.instance.GameStart();
            }
        }
        else if(started && !gameOver)
        {
            transform.Rotate(0,0,rotationAmount);
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        GameManager.instance.GameOver();
        GetComponent<Animator>().Play("ball");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pipe" && !gameOver)
        {
            gameOver = true;
            GameManager.instance.GameOver();
            GetComponent<Animator>().Play("ball");
        }

        if (other.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.instance.IncrementScore();
        }
    }
}
