using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRay : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    Material[] baseMaterials;
    int baseLayer;
    public Material xRayMaterial;
    List<Material> xRayMaterials;
    public UnityEvent onXRay;
    public UnityEvent offXRay;
    bool xRayOn;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        baseMaterials = meshRenderer.materials;
        baseLayer = gameObject.layer;
        xRayMaterials = new List<Material> { xRayMaterial };
        for (int i = 0; i < baseMaterials.Length - 1; i++)
        {
            xRayMaterials.Add(xRayMaterial);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            xRayOn = !xRayOn;
            Invoke("DisableXRay", 10f);
        }
        if (xRayOn != true)
        {
            gameObject.layer = baseLayer;
            meshRenderer.materials = baseMaterials;
            offXRay.Invoke();
        }
        else {
            gameObject.layer = 7;
            meshRenderer.materials = xRayMaterials.ToArray();
            onXRay.Invoke();
        }
        //MODIFY THE SCRIPT BELOW TO BE ACTIVE WHEN THE SPELL IS CAST
        /*
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.main.transform.position - transform.position, out hit))
        {
            if (hit.collider.CompareTag("Player") == false)
            {
                gameObject.layer = 7;
                meshRenderer.materials = xRayMaterials.ToArray();
                onXRay.Invoke();
            }
            else
            {
                gameObject.layer = baseLayer;
                meshRenderer.materials = baseMaterials;
                offXRay.Invoke();
            }
        }
        */
    }

    void DisableXRay()
    {
        xRayOn = false;
    }
}
