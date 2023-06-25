using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D jugador;
    private Vector2 posicionAnteriorJugador;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        posicionAnteriorJugador = jugador.position;
    }

    private void Update()
    {
        if (jugador.position != posicionAnteriorJugador)
        {
            offset.x = (jugador.velocity.x * 0.2f) * velocidadMovimiento.x * Time.deltaTime;
            offset.y = (jugador.velocity.y * 0.2f) * velocidadMovimiento.y * Time.deltaTime;
            material.mainTextureOffset += offset;
        }

        posicionAnteriorJugador = jugador.position;
    }
}
