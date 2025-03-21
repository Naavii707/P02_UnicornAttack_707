using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInstantiate : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms; // Lista de plataformas disponibles
    [SerializeField]
    private GameObject[] safePlatforms; // Las plataformas seguras que no matan al jugador
    [SerializeField]
    private float distanceBetweenPlatforms = 2f; // Distancia entre plataformas
    [SerializeField]
    private int initialPlatforms = 10; // Número de plataformas a instanciar
    private float offsetPositionX = 0f;

    private int platformsInstanciadas = 0; // Contador de plataformas instanciadas

    public void Start()
    {
        offsetPositionX = 0;
        InstantiatePlatforms(initialPlatforms);
    }

    public void InstantiatePlatforms(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // Elegimos una plataforma aleatoria de la lista
            int randomIndex = UnityEngine.Random.Range(0, platforms.Count);

            if (offsetPositionX != 0)
            {
                offsetPositionX += platforms[randomIndex].GetComponent<BoxCollider>().size.x * 0.5f;
            }

            // Instanciamos la plataforma
            GameObject platform = Instantiate(platforms[randomIndex], Vector3.zero, Quaternion.identity);
            offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
            platform.transform.SetParent(transform);
            platform.transform.localPosition = new Vector3(offsetPositionX, 0, 0);

            // Comprobamos si es una de las primeras dos plataformas
            if (platformsInstanciadas < 2)
            {
                // Verificamos si la plataforma es una de las seguras
                if (Array.Exists(safePlatforms, safePlatform => safePlatform.name == platform.name))
                {
                    // Desactivar el Collider para que no cause daño
                    platform.GetComponent<Collider>().isTrigger = true;
                }
            }

            platformsInstanciadas++;
        }
    }

    public void Restart()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        platformsInstanciadas = 0; // Resetear contador al reiniciar
        Start();
    }
}

