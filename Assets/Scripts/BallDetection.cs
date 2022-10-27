using UnityEngine;

public class BallDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectManipulation objectManipulation))
        {
            Debug.Log(other.GetType());

            var ballModelRenderer1 = this.gameObject.GetComponent<Renderer>();
            var ballModelRenderer2 = objectManipulation.GetComponent<Renderer>();

            if (ballModelRenderer1.material.color != ballModelRenderer2.material.color)
            {
                objectManipulation.Test(objectManipulation.transform.position);
                objectManipulation.GetComponent<SphereCollider>().isTrigger = true;
                Destroy(objectManipulation.GetComponent<ObjectManipulation>());

                LaunchNewRaund();
            }

            else
            {
                Destroy(this.gameObject);
                Destroy(objectManipulation.gameObject);

                LaunchNewRaund();
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
