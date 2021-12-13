using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanView : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _mouseSensitivity = 2.5f;

    private float _rotationX = 45f;
    private float _rotationY = 0f;

    void Awake() 
    {
        _rotationX = _cam.transform.rotation.x;
        _rotationY = _cam.transform.rotation.y;
    
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        float scroll = Input.GetAxis("Mouse ScrollWheel") * _mouseSensitivity * Time.deltaTime;

        LeftClickDrag(horizontal, vertical);
        RightClickRotate(horizontal, vertical);
        MouseWheelMove(scroll);

    }

    
    void LeftClickDrag(float horizontal, float vertical)
    {   
   
       if(Input.GetMouseButton(0))
       {
          _cam.transform.Translate(horizontal, vertical, 0f);
       }
    }

    void RightClickRotate(float horizontal, float vertical)
    {
        if(Input.GetMouseButton(1))
        {
            _rotationX -= vertical;
            _rotationY += horizontal;
            _cam.transform.eulerAngles = new Vector3(_rotationX , _rotationY, 0f);
        }
    }

    void MouseWheelMove(float scroll)
    {
        if(scroll != 0)
        {
            _cam.transform.Translate(_cam.transform.forward * scroll);
        }
    }

    
}
