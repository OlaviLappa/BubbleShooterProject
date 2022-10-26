using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManipulation : MonoBehaviour
{
    [SerializeField] private GameObject _launchPoint;
    [SerializeField] private Vector3 _launchPos;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private bool _aimingMode;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void OnMouseDown()
    {
        _aimingMode = true;
        _rigidbody.isKinematic = true;
    }

    private void OnMouseExit()
    {
        _aimingMode = false;
        _rigidbody.isKinematic = false;
    }

    private void Update()
    {
        if (_aimingMode)
        {
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            _rigidbody.position = mousePos3D;
        }
    }
}
