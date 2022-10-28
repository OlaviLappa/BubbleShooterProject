using UnityEngine;
using System.Collections.Generic;

public class BallDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectManipulation objectManipulation))
        {
            var ballModelRenderer1 = this.gameObject.GetComponent<Renderer>();
            var ballModelRenderer2 = objectManipulation.GetComponent<Renderer>();

            if (ballModelRenderer1.material.color != ballModelRenderer2.material.color)
            {
                LaunchNewRaund();

                objectManipulation.Test(objectManipulation.transform.position);
                objectManipulation.GetComponent<SphereCollider>().isTrigger = true;
                Destroy(objectManipulation.GetComponent<ObjectManipulation>());
            }

            else
            {
                LaunchNewRaund();

                SphereCollider sp = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SphereCollider>();
                sp.gameObject.SetActive(true);
                Debug.Log(sp.radius);
            }
        }
    }

    private void LaunchNewRaund()
    {
        UserBall userBall = new UserBall();
        BallThrow ballThrow = new BallThrow();

        StartCoroutine(ballThrow.NextThrow(userBall._onGenerateNewUserBall));
    }
}
