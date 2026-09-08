using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    
    private Rigidbody rb;
    private bool estaEnSuelo;

    void Start()
    {
        // Obtenemos el componente Rigidbody automáticamente
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // --- MOVIMIENTO ---
        Vector3 movimiento = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            movimiento.z = 1;
        if (Keyboard.current.sKey.isPressed)
            movimiento.z = -1;
        if (Keyboard.current.aKey.isPressed)
            movimiento.x = -1;
        if (Keyboard.current.dKey.isPressed)
            movimiento.x = 1;

        // Normalizamos el vector para que en diagonal no se mueva más rápido
        movimiento = movimiento.normalized;

        // Aplicamos movimiento manteniendo la velocidad en Y (gravedad)
        Vector3 velocidadMovimiento = new Vector3(movimiento.x * velocidad, rb.linearVelocity.y, movimiento.z * velocidad);
        rb.linearVelocity = velocidadMovimiento;

        // --- SALTO ---
        // Detectamos si se presiona el espacio y el jugador está en el suelo
        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaEnSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnSuelo = false; // Ya no está en el suelo tras saltar
        }
    }

    // Comprobamos si el personaje toca el suelo (requiere un plano con la etiqueta "Suelo" o capa adecuada)
    private void OnCollisionStay(Collision collision)
    {
        // Puedes cambiar "Suelo" por el tag de tu piso, o quitarlo si cualquier objeto sirve
        estaEnSuelo = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        estaEnSuelo = false;
    }
}