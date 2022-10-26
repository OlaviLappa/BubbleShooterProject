using UnityEngine;

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
        ballModelRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
