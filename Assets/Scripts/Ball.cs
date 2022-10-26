using UnityEngine;

public class Ball : IBall
{
    public Color BallColor { get; set; }
    public Vector3 BallSize { get; set; }

    private const float _zPosition = -6.54f;

    public Ball(Color ballColor, Vector3 ballSize)
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
        ballModel.transform.localScale = BallSize;

        var ballModelRenderer = ballModel.GetComponent<Renderer>();
        ballModelRenderer.material.SetColor("_Color", BallColor);
    }
}
