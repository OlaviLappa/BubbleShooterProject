using UnityEngine;

public class Ball : IBall
{
    public Color BallColor { get; set; }
    public float BallSize { get; set; }

    private const float _zPosition = 1f;

    public Ball(Color ballColor, float ballSize)
    {
        this.BallColor = ballColor;
        this.BallSize = ballSize;
    }

    public void InitNewBall(float x, float y) => CreateNewBallModel(x, y);

    private void CreateNewBallModel(float x, float y)
    {
        GameObject ballModel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ballModel.AddComponent<Renderer>();

        ballModel.transform.position = new Vector3(x, y, _zPosition);
        ballModel.transform.localScale = new Vector3(BallSize, BallSize, BallSize);

        var ballModelRenderer = ballModel.GetComponent<Renderer>();
        ballModelRenderer.material.SetColor("_Color", BallColor);
    }
}
