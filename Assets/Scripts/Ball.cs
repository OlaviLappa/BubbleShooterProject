using UnityEngine;
using System.Collections.Generic;

public class Ball : IBall
{
    public Color BallColor { get; set; }
    public Vector3 BallSize { get; set; }

    protected const float _zPosition = -5.57f;

    public Ball() { }
    public Ball(Color ballColor) => this.BallColor = ballColor;
    public Ball(Vector3 ballSize) => this.BallSize = ballSize;

    public void InitNewBall(float x, float y, int xPos, int yPos) => CreateNewBallModel(x, y, xPos, yPos);

    protected virtual GameObject CreateNewBallModel(float x, float y, int xPos, int yPos)
    {
        GameObject ballModel = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        ballModel.transform.localScale = BallSize;
        ballModel.transform.position = new Vector3(x + BallSize.x * xPos, y + BallSize.y * yPos, _zPosition);
        ballModel.GetComponent<SphereCollider>().isTrigger = true;
        ballModel.AddComponent<BallDetection>();
        var ballModelRenderer = ballModel.GetComponent<Renderer>();
        ballModelRenderer.material.color = GetRandomColor();
        
        return ballModel;
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

public class UserBall : Ball
{
    public delegate GameObject OnGenerateNewUserBall();
    public OnGenerateNewUserBall _onGenerateNewUserBall;

    private List<Ball> _ballCollection;
    private GameObject _userBall;

    public UserBall() => _onGenerateNewUserBall = () => GenerateNewUserBall();
    public UserBall(List<Ball> ballCollection)
    {
        this._ballCollection = ballCollection;
        _onGenerateNewUserBall = () => GenerateNewUserBall();
    }

    public void ShowBallCollection()
    {
        foreach (var item in _ballCollection)
        {
            Debug.Log(item.BallSize);
        }
    }

    private GameObject GenerateNewUserBall()
    {
        _userBall = CreateNewBallModel(0f, 4.66f, 1, 1);

        _userBall.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        _userBall.GetComponent<SphereCollider>().isTrigger = false;

        return _userBall;
    }

    protected override GameObject CreateNewBallModel(float x, float y, int xPos, int yPos)
    {
        return base.CreateNewBallModel(x, y, xPos, yPos);
    }
}
