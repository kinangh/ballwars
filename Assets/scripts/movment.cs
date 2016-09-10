using UnityEngine;
using System.Collections;

public class movment : MonoBehaviour {

    public float speed;

    private bool onground;
    public float jumppressure;

	void Start()
    {
        onground = true;   
    }

	void Update () {
        float movehorizontal = Input.GetAxis("Horizontal");
        Vector2 movment = new Vector3(movehorizontal, 0, 0);
        GetComponent<Rigidbody2D>().AddForce(movment * Time.deltaTime * speed);

        if (Input.GetButton("Jump"))
        {
            if (onground)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumppressure);
                onground = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onground = true;
        }
    }
}
