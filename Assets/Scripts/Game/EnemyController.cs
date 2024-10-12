using UnityEngine;
public class EnemyController : MonoBehaviour
{
   
    Rigidbody2D Rb2D;
    [SerializeField] private float speed;
    private void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Rb2D.velocity=new Vector2(-speed,0);
    }
}
