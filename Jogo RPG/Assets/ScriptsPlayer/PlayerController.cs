using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento do jogador
    public float jumpHeight = 2f; // Altura do pulo do jogador
    public float gravity = -10.0f; // Gravidade aplicada ao jogador
    public Transform groundCheck; // Transform para verificar se o jogador está no chão
    public float groundDistance = 0.4f; // Distância para verificar se o jogador está no chão
    public LayerMask groundMask; // LayerMask para definir quais camadas representam o chão

    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verifica se o jogador está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resetar a velocidade vertical quando estiver no chão para evitar acumulação
        }

        // Movimento do jogador
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Aplicar a gravidade ao jogador
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Pular
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
