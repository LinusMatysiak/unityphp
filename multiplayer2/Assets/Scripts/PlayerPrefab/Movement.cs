using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 10;
    Vector2 Direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        Direction.x = Input.GetAxisRaw("Horizontal");
        Direction.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate() {
        rb.position += Direction * speed * Time.deltaTime;
    }
}
