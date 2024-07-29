using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    public GameObject Emission;
    private Renderer render;
    private Material material;
    // Start is called before the first frame update
    private void Start()
    {
        render = Emission.GetComponent<Renderer>();
        material = render.material;
    }
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLights());
        }
    }

    IEnumerator FlickeringLights()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        material.DisableKeyword("_EMISSION");
        timeDelay = Random.Range(0.3f, 0.8f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;

    }
}
