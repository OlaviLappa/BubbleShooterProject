using UnityEngine;

public class BallGroupsCreating : MonoBehaviour
{
    private BallDetection ballDetection1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BallDetection ballDetection)) //первичное вхождение
        {
            ballDetection1 = ballDetection;

            var ballModelRenderer1 = this.gameObject.transform.GetComponentInParent<Renderer>();
            var ballModelRenderer2 = ballDetection1.GetComponent<Renderer>();

            if (ballModelRenderer1.material.color == ballModelRenderer2.material.color)
            {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                Object.Destroy(other.gameObject);
                Object.Destroy(ballModelRenderer1.gameObject);
            }
        }
    }
}
