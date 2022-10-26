using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : MonoBehaviour
{
    [SerializeField] private List<Ball> _ballsCollection;
    [SerializeField] private int _collectionLength;

    private void Start()
    {
        _ballsCollection = new List<Ball>();

        for (int i = 0; i < _collectionLength; i++)
        {
            Color color = new Color();
            Ball _ball = new Ball(color, Random.Range(0, 5));
            _ball.SetBallPosition(Random.Range(0, 10), Random.Range(0, 10));

            _ballsCollection.Add(_ball);
        }
    } 
}
