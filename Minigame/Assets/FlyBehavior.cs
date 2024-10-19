using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = Unity.Mathematics.Random;

public class FlyBehavior : MonoBehaviour
{
    public float _velocity = 3f;
    
    public float _rotationSpeed = 10f;

    private Color[] colors = { Color.red, Color.green, Color.yellow };
    // Start is called before the first frame update
    
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        
        Color randomColor = colors[UnityEngine.Random.Range(0, colors.Length)];
        
        _sr.color = randomColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * _velocity;
        }
        transform.Translate(Vector2.right * _velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TrashCan"))
        {
            //_sr.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            if (_sr.color == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                Debug.Log("You win");
            }
            else
            {
                Debug.Log("You lose");
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
