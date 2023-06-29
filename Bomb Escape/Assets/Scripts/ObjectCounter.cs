using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public int targetCount = 3; // Número de objetos objetivo a eliminar
    private int currentCount = 0; // Número de objetos eliminados actualmente

    public void ObjectDestroyed()
    {
        currentCount++;

        if (currentCount >= targetCount)
        {
            ShowCongratulationsMessage();
        }
    }

    private void ShowCongratulationsMessage()
    {
        Debug.Log("¡Felicidades!");
        // Aquí puedes mostrar un mensaje en pantalla, reproducir un sonido, mostrar una interfaz de usuario, etc.
    }
}
