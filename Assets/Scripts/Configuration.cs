using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : MonoBehaviour
{
    [SerializeField] private List<Ball> _ballsCollection;

    [SerializeField] private int _collectionLength;
    [SerializeField] private int _collectionDeep;

    private void Start()
    {
        _ballsCollection = new List<Ball>();
        GameObject _ballObejct = new GameObject();

        for (int i = 1; i < _collectionLength; i++)
        {
            for (int j = 1; j < _collectionDeep; j++)
            {
                Ball _ball = new Ball(new Vector3(0.4f, 0.4f, 0.4f));
                _ball.InitNewBall(_ballObejct, -3.41f, 7.3f, i, j);

                _ballsCollection.Add(_ball);
            }
        }

        UserBall user = new UserBall();
        BallThrow ballThrow = new BallThrow();

        StartCoroutine(ballThrow.NextThrow(user._onGenerateNewUserBall));
    }

    private void Update()
    {
        
    }
}
