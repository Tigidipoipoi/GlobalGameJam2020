using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTuto : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
