using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManipulation : MonoBehaviour
{
    [SerializeField] private Vector3 _launchPos;
    [SerializeField] private bool _aimingMode;

    private bool _isFliengStart = false;

    private Vector3 direction;
    private Vector3 _lastPosition;
    private Vector3 aVector, bVector;

    private float _speed = 9f;

    private void Start()
    {
        _aimingMode = false;
        _launchPos = this.gameObject.transform.position;
    }

    private void OnMouseDrag() => _aimingMode = true;
    bool t = false;
    Vector3 lasPos;

    protected virtual void Update() ///вынести всю логику в класс BallThrow, сюда передавать только делегат с ссылкой на метод
    {
        if (_aimingMode)
        {
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - _launchPos;

            float maxMagnitude = this.GetComponent<SphereCollider>().radius * 2;

            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            _lastPosition = _launchPos + mouseDelta;
            this.gameObject.transform.position = new Vector3(_lastPosition.x, _lastPosition.y, -11.21f);

            if (Input.GetMouseButtonUp(0))
            {
                _aimingMode = false;
                _isFliengStart = true;
                _lastPosition = transform.position;
            }
        }

        if (_isFliengStart)
        {
            aVector = _lastPosition;
            bVector = _launchPos;

            direction = bVector - aVector;
            transform.position += (direction * Time.deltaTime * _speed);

            /*if (lasPos != null)
            {
                direction.x = -direction.x;
            }*/
        }

        /*if (t)
        {
            aVector = _lastPosition;
            bVector = _launchPos;

            direction = bVector - aVector;
            transform.position += (new Vector3(-direction.x, direction.y, direction.z) * Time.deltaTime * _speed);
        }*/
    }

    public void Test(Vector3 lastPos)
    {
        _isFliengStart = false;
        lasPos = lastPos;
        //t = true;
        //_isFliengStart = false;
    }
}
