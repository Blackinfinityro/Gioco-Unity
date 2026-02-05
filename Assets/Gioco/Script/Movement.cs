using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float velocità = 5f;

    [SerializeField]
    float forzaSalto = 12f;

    [SerializeField]
    Transform controlloTerreno;
     [SerializeField]
    Transform controlloMuro;

    [SerializeField]
    LayerMask terreno;

    [SerializeField]
    LayerMask wallJump;

    [SerializeField]
    PhysicsMaterial2D groundMaterial;

    [SerializeField]
    PhysicsMaterial2D noFriction;

    Rigidbody2D rb;
    Animator animator;
    float movimentoGiocatore;
    float scalaInizialeX;
    int runRequest;
    bool isGrounded;
    bool isGripped;
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
        isGrounded = Physics2D.OverlapCircle(controlloTerreno.position, 1f, terreno);
        isGripped = Physics2D.OverlapCircle(controlloMuro.position, 1f, wallJump);
        movimentoGiocatore = Input.GetAxis("Horizontal");
        animator.SetFloat("Velocità", Mathf.Abs(movimentoGiocatore));
        Flip(movimentoGiocatore);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequest = true;
        }
        if (Input.GetButtonDown("Run"))
        {
            runRequest = 1;
            Debug.Log("Run");
        }
        if (Input.GetButtonUp("Run"))
        {
            runRequest = 2;
        }
    }

    void FixedUpdate()
    {
        ChangeVelocity();
        ChangeMaterial();
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
        if (direzione == 0)
            return;
        {
            transform.localScale = new Vector3(
                scalaInizialeX * Mathf.Sign(direzione),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    void ChangeVelocity()
    {
        if (runRequest == 1 && velocità == 15)
        {
            velocità += 20;
        }
        if (runRequest == 2)
        {
            if (Time.time - lastSlowDown >= 1)
            {
                velocità -= 2;
                velocità = Mathf.Max(15, velocità);
                lastSlowDown = Time.time;
            }
        }
        else
            lastSlowDown = float.NegativeInfinity;
    }

    void ChangeMaterial()
    {
        if (isGrounded)
        {
            rb.sharedMaterial = groundMaterial;
        }
        if (isGripped)
        {
            rb.sharedMaterial = noFriction;
        }
    }
}
