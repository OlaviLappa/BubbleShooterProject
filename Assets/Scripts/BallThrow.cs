using System.Collections;
using UnityEngine;
using static UserBall;

public class BallThrow
{
    private GameObject _currentBall;

    public IEnumerator NextThrow(OnGenerateNewUserBall onGenerateNewUserBall)
    {
        yield return new WaitForSeconds(2f);

        _currentBall = onGenerateNewUserBall();
        _currentBall.AddComponent<ObjectManipulation>();
    }
}
