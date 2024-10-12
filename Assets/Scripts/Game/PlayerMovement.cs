using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    public int player_lives = 4;
    private float xDirection;
    private float Point;
    [SerializeField] private AudioClipSO clip;
    [SerializeField] private AudioClipSO Puntos;
    [SerializeField] private float limitSuperior;
    [SerializeField] private float limitInferior;
    [SerializeField] private float speed;
    private bool interactue=true;
    Vector2 respawn;
    public static event Action<float> EventPoint;
    public static event Action<float> EventLife;
    private void ActiveEventPoint(float point)
    {
        EventPoint?.Invoke(point);
    }
    private void ActiveEventLife()
    {
        EventLife?.Invoke(player_lives);
    }
    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        respawn = new Vector2(transform.position.x, 0);
        ActiveEventLife();
    }
    private void FixedUpdate()
    {
        if (xDirection>0 && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (xDirection<0 && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }
    }
    public void YDirection(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            Point = other.GetComponent<CandyController>().Point;
            ActiveEventPoint(Point);
            Destroy(other.gameObject);
        }
        if (other.tag == "Point")
        {
            Puntos.PlayOneShoot();
            Point = other.GetComponent<Puntos>().puntos;
            ActiveEventPoint(Point);
            Destroy(other.gameObject);
        }
        if (interactue)
        {
            if (other.CompareTag("Enemy"))
            {
                clip.PlayOneShoot();
                interactue = false;
                --player_lives;
                ActiveEventLife();
                Destroy(other.gameObject);
                transform.position = respawn;
                StartCoroutine(TiempoEspera());
            }
        }
    }
    private IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(1);
        interactue=true;  
    }
}
