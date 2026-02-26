using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static SnakeManager Instance { get; private set; }
    public GameObject snakeHeadObject;
    public GameObject bodyPrefab;
    private ISnake snakeHead;
    private ISnake snakeTail;
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
        snakeHead = snakeHeadObject.GetComponent<ISnake>();
        SetSnakeTail(snakeHead);
    }

    public void SetSnakeTail(ISnake snakeTail)
    {
        this.snakeTail = snakeTail;
    }

    public ISnake GetSnakeTail()
    {
        return snakeTail;
    }

    void GenerateBody(ISnake frontSnake)
    {
        GameObject bodyObj = Instantiate(bodyPrefab);

        BodyBehaviour body = bodyObj.GetComponent<BodyBehaviour>();

        if (body == null)
        {
            Debug.LogError("BodyBehaviour が付いていません");
            return;
        }

        body.SetFrontSnake(frontSnake);
    }
}
