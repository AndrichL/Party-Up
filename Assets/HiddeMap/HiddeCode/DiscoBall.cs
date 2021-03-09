using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBall : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float changeTime = 10f;
    [SerializeField] Material[] materials;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] float rotationSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        StartCoroutine(ColourChange());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

    }

    IEnumerator ColourChange()
    {
        while (!GameManager.instance.gameIsPaused)
        {
            
            int materialUsed;
            materialUsed = Random.Range(0, materials.Length);

            mesh.material = materials[materialUsed];

            yield return new WaitForSeconds(changeTime);
        }

    }

}
