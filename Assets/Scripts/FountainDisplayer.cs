using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FountainDisplayer : MonoBehaviour
{
    public GameObject objects;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "fountain")
                    {
                        objects.SetActive(true);
                    }

                }
                else
                {
                    Debug.Log("Collider not found");
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "fountain")
                    {
                        objects.SetActive(true);
                    }

                }
            }
        }
    }
    public void closeInformation()
    {
        objects.SetActive(false);
    }
}
