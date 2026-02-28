using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehaviour : MonoBehaviour
{
    private SnakeManager snakeManager;
    private AppleManager appleManager;
    public AudioClip eatClip;
    // Start is called before the first frame update
    void Start()
    {
        snakeManager = SnakeManager.Instance;
        appleManager = AppleManager.Instance;
        appleManager.AddAppleCount();
    }

    void OnDisable()
    {
        appleManager.SubAppleCount();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Headタグが付いているか確認
        if (other.CompareTag("Head"))
        {
            GameObject frontSnake = snakeManager.GetSnakeTail();
            snakeManager.GenerateBody(frontSnake);
            AudioManager.Instance.PlaySe(eatClip, 1f);
            Destroy(gameObject,2f);
        } else
        {
            Destroy(gameObject);
        }
    }
}
