using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class moverjogador : MonoBehaviour
{
    public float movespeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    private float position = 1;
    private Animator animator;
    private bool isRunning = false;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start() // atualiza antes do jogo começar
    {
        rb = GetComponent<Rigidbody2D>(); // para chamar a gravidade com o nome "rb"
        animator = GetComponent<Animator>(); // para chamar a animação com nome "animator"
        animator.SetBool("isRunning", false); // config. para iniciar parado ou walk
        animator.SetBool("isJumping", false); // config. para iniciar parado

    }

    // Update is called once per frame
    void Update() // atualiza a cada frame
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // Para config. o input para corrida na horizontal

        if (moveInput != 0) // if/else para saber se o input for diferente de zero, está correndo
        {
            isRunning = true;
        }
        else 
        { 
            isRunning = false;
        }

        animator.SetBool("isRunning", isRunning); // Para setar animação Run

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // Função para correr se pressionar a tecla space e se não estiver pulando
        {
            Jump();
        }

    }
    void FixedUpdate() // atualiza a cada momento que o input acontecer
    {

        rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y); // para calcular a velocidae da corrida

        if (moveInput > 0) // esse if/else é para decidir a direção do personagem e a animação com o input. input positivo é movimento da esquerda para direita
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            position = 1f;

        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            position = -1f;

        }
        else
        {
            transform.localScale = new Vector3(position, 1f, 1f);
        }

        if (Mathf.Abs(rb.velocity.y) > 0.01f) // para definir quando a config da animação de pular é verdadeira (eixo y)
        {
            isJumping = true; 
            animator.SetBool("isJumping", true);
        } else 
        {
            isJumping = false ;
            animator.SetBool("isJumping", false);
        }
    }
    void Jump() // função para pular chamado lá em cima no update
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f); // para saber se o objeto está colidindo com o chão
        if (hit.collider != null) // caso esteja colodindo com o chão, config um vetor com força de pulo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // define a força vetorial do pulo
            animator.SetBool("isJumping", true); // ativar a animação quando a função jump for chamada
        }
    }
}
