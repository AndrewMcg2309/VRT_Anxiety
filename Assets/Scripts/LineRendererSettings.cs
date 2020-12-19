using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererSettings : MonoBehaviour
{
    // store component attached to the GameObject
    [SerializeField] LineRenderer rend;

    // Settings for the LineRenderer are stor3ed as a Vector3 array of points. Set up a v£
    // array to initialize in start
    Vector3[] points;


    // declare the panel to change
    public GameObject panel;
    public Image img;
    public Button butn;


    void Start()
    {
        img = panel.GetComponent<Image>();

        // get the LineRenderer attached to the gameObject
        rend = gameObject.GetComponent<LineRenderer>();
        
        // initialize the LineRenderer
        points = new Vector3[2];

        // set the start point of the line renderer to the position of the gameObject 
        points[0] = Vector3.zero;

        // points forward on z axis
        points[1] = transform.position + new Vector3(0,0,20);

        // set the positions array on the LineRenderer to out new values
        rend.SetPositions(points);
        rend.enabled = true;
    }

   
    public LayerMask layerMask;

    public void AlignLineRenderer(LineRenderer rend)
    {
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, layerMask))
        {
            butn = hit.collider.gameObject.GetComponent<Button>();
            points[1] = transform.forward + new Vector3(0,0,hit.distance);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0,0,20);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;
    }

    void update()
    {
        AlignLineRenderer(rend);
    }
}
