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

        for (int i = 1; i < _collectionLength; i++)
        {
            for (int j = 1; j < _collectionDeep; j++)
            {
                Ball _ball = new Ball(new Vector3(0.1f, 0.1f, 0.1f));
                _ball.InitNewBall(-1f, 6.4f, i, j);

                _ballsCollection.Add(_ball);
            }
        }

        UserBall user = new UserBall(_ballsCollection);
        BallThrow ballThrow = new BallThrow();

        StartCoroutine(ballThrow.NextThrow(user._onGenerateNewUserBall));
    } 
}
