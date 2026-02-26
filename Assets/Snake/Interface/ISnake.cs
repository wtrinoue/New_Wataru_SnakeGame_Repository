using UnityEngine;

public interface ISnake
{
    public void Move();

    public Vector3 GetPastPosition();

    public void SetFrontSnake(ISnake frontSnake);
}