using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageChanger : MonoBehaviour
{
    [SerializeField] private float changeTime = 5f; // Tiempo después del cual se reemplazará la imagen de fondo
    [SerializeField] private Sprite[] backgroundSprites; // Arreglo de imágenes de fondo

    private Image backgroundImage;
    private int currentSpriteIndex = 0;
    private float elapsedTime = 0f;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();

        // Verificar si hay sprites asignados en el arreglo
        if (backgroundSprites.Length > 0)
        {
            backgroundImage.sprite = backgroundSprites[currentSpriteIndex]; // Establecer la primera imagen de fondo

            if (backgroundSprites.Length > 1)
            {
                InvokeRepeating("ChangeBackground", changeTime, changeTime); // Iniciar el cambio de imágenes en un bucle
            }
        }
        else
        {
            Debug.LogWarning("No sprites assigned for background in BackgroundImageChanger script on object: " + gameObject.name);
        }
    }

    private void ChangeBackground()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % backgroundSprites.Length;
        backgroundImage.sprite = backgroundSprites[currentSpriteIndex];
    }
}
