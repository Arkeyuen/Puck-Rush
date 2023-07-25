using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public float cylinderSize = .2f;
    public int cylindersInRow = 5;


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
    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        piece.transform.position = transform.position + new Vector3(cylinderSize*x, cylinderSize*y, cylinderSize * z);
        piece.transform.localScale = new Vector3(cylinderSize, cylinderSize, cylinderSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cylinderSize;
    }
}
