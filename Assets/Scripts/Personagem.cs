using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personagem : MonoBehaviour
{

    public Transform npc;
    public float velocidade = 5;

    Rigidbody2D rigidbody;

    float horizontal;
    float vertical;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessaInputs();
    }

    void FixedUpdate()
    {
        MovimentaJogador();
        //RotacionaMovimento();
        RotacionaMouse();
    }

    /// <summary>
    /// Lê os inputs do jogador nos eixos horizontal e vertical e os armazena.
    /// </summary>
    void ProcessaInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Move o personagem com base nos inputs lidos, considerando a velocidade e normalizando quando necessário.
    /// </summary>
    void MovimentaJogador()
    {
        Vector2 movimento = new Vector2(horizontal, vertical);
        if (movimento.magnitude > 1)
        {
            // Normalizar os eixos pra não somar as duas direções e ir na mesma velocidade
            movimento = movimento.normalized;
        }
        movimento = movimento * velocidade;

        rigidbody.linearVelocity = movimento;
    }

    /// <summary>
    /// Rotaciona o personagem na direção do movimento com base nos eixos horizontal e vertical.
    /// </summary>
    void RotacionaMovimento()
    {
        // return early
        if (vertical == 0 && horizontal == 0)
        {
            return;
        }

        float angulo = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
        rigidbody.rotation = angulo;
    }

    /// <summary>
    /// Rotaciona o personagem para olhar na direção do cursor do mouse.
    /// </summary>
    void RotacionaMouse()
    {
        Vector3 posicaoMundoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Utils.OlharParaObjeto(transform, posicaoMundoMouse);
    }


    /*
     
        ATIVIDADE: Cutscene

        Crie um objeto no seu cenário, simulando um NPC.
        Ao apertar a tecla F você deve entrar no modo Cutscene

        O modo cutscene:
        - O jogador não pode se mover
        - O jogador deve olhar para o NPC
        - Pressionar a tecla G, sai da cutscene e volta ao normal

        conrado.sasaud@sp.senac.br
     
     */




}
