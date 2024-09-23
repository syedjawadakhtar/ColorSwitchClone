using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPlayer : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Transform camera;
    private int totalStars = 0;
    public TMP_Text totalStarsText;
    public TMP_Text GameOverText;
    public Canvas GameOver;
    public Canvas ScoreCounter;
    public GameObject playerDeathEffect;
    public GameObject starCollectedEffectPrefab; 
    public AudioClip blingSound; 
    public AudioClip gameOverSound; 
    public AudioClip changeColorSound; 
    private AudioSource audioSource; 

    private Rigidbody2D rb2D;
    private Vector3 cameraVelocity = Vector3.zero;
    private float smoothTime = 0.3f; // For camera movement
    private float moveSpeed = 5.0f; // Player movement speed

    void Start()
    {
        // Randomly assign material to player
        Material[] materials = { material1, material2, material3, material4 };
        GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
        
        // Initialize Rigidbody2D if not already assigned
        rb2D = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
        rb2D.gravityScale = 1; 
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;

        UpdateStarDisplay();
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        // Handle player movement
        HandleMovement();

        // Camera follow player when mouse is pressed
        HandleCameraMovement();

        // Check if player falls off the screen
        if (transform.position.y < camera.transform.position.y - 5.0f)
        {
            EndGame();
        }
    }

    void HandleMovement()
    {
        if (Input.GetMouseButton(0))
        {
            rb2D.velocity = Vector2.up * moveSpeed;
        }
        else
        {
            rb2D.velocity = Vector2.down * moveSpeed;
        }
    }

    void HandleCameraMovement()
    {
        if (Input.GetMouseButton(0) && transform.position.y >= 4.0f)
        {
            Vector3 targetPosition = new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z);
            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref cameraVelocity, smoothTime);
        }
    }

    void EndGame()
    {
        Instantiate(playerDeathEffect, transform.position, Quaternion.identity).SetActive(true);

        GameObject soundObject = new GameObject("DeathSoundObject");
        AudioSource soundSource = soundObject.AddComponent<AudioSource>();
        soundSource.clip = gameOverSound;
        soundSource.Play();
        Destroy(soundObject, gameOverSound.length);
        
        GameOver.gameObject.SetActive(true);
        ScoreCounter.gameObject.SetActive(false);
        
        GameOverText.text = $"Game Over! \n \n Total Stars Collected: {totalStars}";
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WhiteStar"))
        {
            totalStars++;
            UpdateStarDisplay();
            PlaySound(blingSound);
            Instantiate(starCollectedEffectPrefab, other.transform.position, Quaternion.identity).SetActive(true);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ColorSwitcher"))
        {
            Material currentMaterial = GetComponent<Renderer>().material;
            List<Material> availableMaterials = new List<Material> { material1, material2, material3, material4 };
            availableMaterials.Remove(currentMaterial);
            GetComponent<Renderer>().material = availableMaterials[Random.Range(0, availableMaterials.Count)];
            PlaySound(changeColorSound);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
            {
                EndGame();
            }
        }
    }

    void UpdateStarDisplay()
    {
        if (totalStarsText != null)
        {
            totalStarsText.text = $"Stars Collected: {totalStars}";
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
