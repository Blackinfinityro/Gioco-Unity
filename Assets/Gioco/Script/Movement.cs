using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float velocità = 5f;
    private Rigidbody2D rb;
    private Input controls;
    private Rigidbody2D rigidBody;
    float movimentoGiocatore;

    private Vector2 moveInput;
        void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimentoGiocatore = controls.Movement.horizontal.ReadValue<float>();
    }

    void FixedUpdate()
    {
        rigidBody.linearVelocityX = velocità * movimentoGiocatore;
    }
}
