using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static SnakeManager Instance { get; private set; }
    public GameObject snakeHead;
    public GameObject bodyPrefab;
    private GameObject snakeTail;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        SetSnakeTail(snakeHead);
    }

    public void SetSnakeTail(GameObject snakeTail)
    {
        this.snakeTail = snakeTail;
    }

    public GameObject GetSnakeTail()
    {
        return snakeTail;
    }

    public void GenerateBody(GameObject frontSnake, GameObject apple)
    {
        Vector3 applePosition = apple.transform.position;
        GameObject body = Instantiate(
            bodyPrefab,
            applePosition,
            Quaternion.identity
        );
        var bodySnake = body.GetComponent<ISnake>();
        bodySnake.SetFrontSnake(frontSnake);
        SetSnakeTail(body);
    }
}
