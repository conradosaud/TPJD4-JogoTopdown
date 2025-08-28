using UnityEngine;

public class Personagem : MonoBehaviour
{

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
    }

    void ProcessaInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void MovimentaJogador()
    {
        rigidbody.linearVelocity = new Vector2(horizontal, vertical) * velocidade;
    }

}
