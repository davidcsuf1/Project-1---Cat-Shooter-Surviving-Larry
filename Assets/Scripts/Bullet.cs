using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 2f;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifetime);
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + (Vector2)transform.up * speed * Time.fixedDeltaTime);
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}