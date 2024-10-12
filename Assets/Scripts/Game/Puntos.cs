using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    Rigidbody2D Rb2D;
    [SerializeField] private float speed;
    public float puntos;
    private void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Rb2D.velocity = new Vector2(-speed, 0);
    }
}
