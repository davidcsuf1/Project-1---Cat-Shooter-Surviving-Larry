using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private SimplePool pool;

    private Vector2 aimDirection = Vector2.up;

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (input != Vector2.zero)
        {
            aimDirection = input;
        }
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject obj = pool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.up = aimDirection;
        }
    }
}