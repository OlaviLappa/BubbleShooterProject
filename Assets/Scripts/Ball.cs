using UnityEngine;

public class Ball : IBall
{
    public Color BallColor { get; set; }
    public float BallSize { get; set; }

    public Ball(Color ballColor, float ballSize)
    {
        this.BallColor = ballColor;
        this.BallSize = ballSize;
    }

    public void SetBallPosition(float x, float y)
    {
        Debug.Log("x: " + x + " " + "y: " + y);
    }
}
