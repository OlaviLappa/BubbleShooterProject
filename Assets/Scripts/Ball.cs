using UnityEngine;
using System.Collections.Generic;

public class Ball : IBall
{
    public Color BallColor { get; set; }
    public Vector3 BallSize { get; set; }

    private const float _zPosition = -6.54f;

    public Ball(Color ballColor) => this.BallColor = ballColor;
    public Ball(Vector3 ballSize) => this.BallSize = ballSize;

    public void InitNewBall(float x, float y, int xPos, int yPos) => CreateNewBallModel(x, y, xPos, yPos);

    private void CreateNewBallModel(float x, float y, int xPos, int yPos)
    {
        GameObject ballModel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ballModel.AddComponent<Renderer>();

        ballModel.transform.localScale = BallSize;
        ballModel.transform.position = new Vector3(x + BallSize.x * xPos, y + BallSize.y * yPos, _zPosition);

        var ballModelRenderer = ballModel.GetComponent<Renderer>();
        ballModelRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        int index = Random.Range(0, 5);

        List<Color> colors = new List<Color>
        {
            Color.black,
            Color.white,
            Color.green, 
            Color.red,
            Color.cyan,
            Color.blue,
            Color.gray
        };

        return colors[index];
    }
}
