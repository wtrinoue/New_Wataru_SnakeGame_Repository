using UnityEngine;

public interface ISnake
{
    public void Move();

    public Vector3 GetPastPosition();

    public Vector3 GetCurrentPosition();

    public void SetFrontSnake(GameObject frontSnake);
}