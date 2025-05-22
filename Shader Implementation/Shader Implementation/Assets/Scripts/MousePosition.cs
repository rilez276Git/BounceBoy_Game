using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    //CharacterController controller;

    Vector3 Direction;
    [SerializeField] float speed;
    [SerializeField] Camera maincamera;
     void Start()
    {
        //controller = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        Movement();
    }

    void Movement() {
        //float Horizontal = Input.GetAxis("Horizontal");
        //float Vertical = Input.GetAxis("Vertical");
        //Direction = new Vector3(-Vertical, 0, Horizontal);

        //controller.Move(Direction * speed * Time.deltaTime);

        //how to look around 
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            Vector3 LookPosition = hit.point;
            LookPosition.y = this.transform.position.y;
            this.transform.LookAt(LookPosition);
        }

    }
}
