using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public float cylinderSize = .2f;
    public int cylindersInRow = 5;

    float cylindersPivotDistance;
    Vector3 cylindersPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    private void Start()
    {
        cylindersPivotDistance = cylinderSize * cylindersInRow / 2;

        cylindersPivot = new Vector3(cylindersPivotDistance, cylindersPivotDistance, cylindersPivotDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HardWall")
        {
            explode();
        }
    }

    public void explode()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cylindersInRow; x++)
        {
            for (int y = 0; x < cylindersInRow; y++)
            {
                for (int z = 0; x < cylindersInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        piece.transform.position = transform.position + new Vector3(cylinderSize * x, cylinderSize * y, cylinderSize * z) - cylindersPivot;
        piece.transform.localScale = new Vector3(cylinderSize, cylinderSize, cylinderSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cylinderSize;
    }
}
