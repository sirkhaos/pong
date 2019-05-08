using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Vector2 direccion;
    private Rigidbody2D ballRigidbody;
    public bool ballStop;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = gameObject.GetComponent<Rigidbody2D>();
        ballStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ballStop)
        {
            ballRigidbody.velocity = direccion * speed;
            ballStop = false;
        }
        if (ballStop)
        {
            ballRigidbody.velocity = Vector2.zero;
            direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.name.Equals("Top") || collision.name.Equals("Botton"))
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x,ballRigidbody.velocity.y * -1);
        }
        else
        {*/
        if (collision.tag.Equals("Player"))
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x * -1, ballRigidbody.velocity.y);
            ballRigidbody.velocity *= 1.1f;
        }
        //}
    }
}