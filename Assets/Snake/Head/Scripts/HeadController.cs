using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity 2022.3.50f1
public class HeadController : MonoBehaviour, ICoroutineUpdatable
{
    // 現在の進行方向
    private Vector2Int direction = Vector2Int.right;

    void Start()
    {
        if (CoroutineManager.Instance != null)
        {
            CoroutineManager.Instance.Register(this);
        }
    }

    void OnDisable()
    {
        if (CoroutineManager.Instance != null)
        {
            CoroutineManager.Instance.Unregister(this);
        }
    }

    public void ManagedCoroutine(float interval)
    {
        Debug.Log("進みました！");
        Move();
    }

    void Update()
    {
        // 上
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector2Int.down)
        {
            direction = Vector2Int.up;
        }
        // 下
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector2Int.up)
        {
            direction = Vector2Int.down;
        }
        // 左
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector2Int.right)
        {
            direction = Vector2Int.left;
        }
        // 右
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector2Int.left)
        {
            direction = Vector2Int.right;
        }
    }

    public void Move()
    {
        // 現在位置を取得
        Vector3 currentPos = transform.position;

        // 1マス進む（1ユニット進む想定）
        Vector3 newPos = currentPos + new Vector3(direction.x, direction.y, 0) * 0.5f;

        transform.position = newPos;
    }
}