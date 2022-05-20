using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public int speed = 2;
    private int count;
    private AudioSource audioSource;
    public AudioClip crunchyClip;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    private bool won = false;
    private bool lost = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = crunchyClip;
        count = 0;
        SetCountText();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        SetCountText();
        if (won)
        {
            SetWinText();
            Application.Quit();
        }
        if (lost)
        {
            SetLoseText();
            Application.Quit();
        }
    }

    private void SetCountText()
    {
        countText.text = "Jieun Seong \nPlayer Score: " + count.ToString();
    }

    private void SetWinText()
    {
        winText.text = "You Won!";
    }

    private void SetLoseText()
    {
        loseText.text = "You Lost!";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUps"))
        {
            count++;
            audioSource.Play();
            other.gameObject.SetActive(false);
            if (GameObject.FindGameObjectsWithTag("PickUps").Length == 0)
            {
                won = true;
            }
        }
        else if (other.gameObject.CompareTag("Dangers"))
        {
            count--;
            audioSource.Play();
            other.gameObject.SetActive(false);
            if (count < 0)
            {
                lost = true;
            }
        }
    }
}
