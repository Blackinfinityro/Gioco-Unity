using System.Reflection;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float velocità = 5f;
    [SerializeField] float forzaSalto = 12f;
    [SerializeField] Transform controlloTerreno;
    [SerializeField] LayerMask terreno;
    Rigidbody2D rb;
    Animator animator;
    float movimentoGiocatore;
    float scalaInizialeX;
    bool isGrounded;
    bool jumpRequest;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scalaInizialeX = Mathf.Abs(transform.localScale.x);
    }

    void Update()
    {
        movimentoGiocatore = Input.GetAxis("Horizontal");
        animator.SetFloat("Velocità", Mathf.Abs(movimentoGiocatore));
        Flip(movimentoGiocatore);
        isGrounded = Physics2D.OverlapCircle(controlloTerreno.position, 0.2f, terreno);
        if (Input.GetButtonDown("Jump") && isGrounded)
            jumpRequest = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimentoGiocatore * velocità, rb.linearVelocity.y);
        if (jumpRequest)
            {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forzaSalto);
            jumpRequest = false;
            }
    }
    void Flip(float direzione)
{
    if (direzione == 0) return;

    transform.localScale = new Vector3(
        scalaInizialeX * Mathf.Sign(direzione),
        transform.localScale.y,
        transform.localScale.z
    );
}

}

