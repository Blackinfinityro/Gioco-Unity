using System.Reflection;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

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
    int runRequest;
    bool isGrounded;
    bool jumpRequest;
    float lastSlowDown = float.NegativeInfinity;
    

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
        isGrounded = Physics2D.OverlapCircle(controlloTerreno.position, 1f, terreno);
        if (Input.GetButtonDown("Jump") && isGrounded)
            jumpRequest = true;
        if (Input.GetButtonDown("Run")) {
            runRequest = 1;
            Debug.Log("Run");
        }
        if (Input.GetButtonUp("Run")) {
            runRequest = 2;
        }
    }

    void FixedUpdate()
    {
        ChangeVelocity();
        rb.linearVelocity = new Vector2(movimentoGiocatore * velocità, rb.linearVelocity.y);
        if (jumpRequest)
            {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forzaSalto);
            
            jumpRequest = false;
            }
        if (movimentoGiocatore == 0)
        {
            velocità = 15;
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

void ChangeVelocity()
    {
        if (runRequest == 1 && velocità == 15)
        {
            velocità += 20;
            
        }
        if (runRequest == 2)
        {
            if (Time.time - lastSlowDown >= 1) {
                velocità -= 2;
                velocità = Mathf.Max(15, velocità);
                lastSlowDown = Time.time;
            }
        } else
            lastSlowDown = float.NegativeInfinity;
    }
}

