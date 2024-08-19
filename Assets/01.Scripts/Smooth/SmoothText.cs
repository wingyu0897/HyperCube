using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothText : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Hide", 0.75f);
    }
   public void view()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
