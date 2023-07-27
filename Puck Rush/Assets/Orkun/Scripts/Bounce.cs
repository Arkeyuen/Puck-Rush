using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float turnSpeed = 5f;
    private bool isTurning = false;
    private Quaternion targetRotation;

    private void Update()
    {
        if (isTurning)
        {
            // Oyuncunun yavaþça dönmesi için rotasyonu yumuþat
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            // Hedef rotasyona yaklaþtýkça dönme iþlemini bitir
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isTurning = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Eðer çarpýþma duvarla gerçekleþtiyse
        if (collision.gameObject.CompareTag("SoftWall"))
        {
            // Oyuncunun yüzüne çarpan duvarýn normal vektörünü al
            Vector3 wallNormal = collision.contacts[0].normal;

            // Kamera yönüne göre yatay düzlemde duvarýn normalini düzelt
            Camera mainCamera = Camera.main;
            wallNormal = Vector3.ProjectOnPlane(wallNormal, mainCamera.transform.up);

            // Yüzün dönme yönünü belirlemek için oyuncunun ileri doðru vektörünü al
            Vector3 forwardDirection = transform.forward;

            // Duvarýn normal vektörü ve oyuncunun ileri doðru vektörü arasýndaki açýyý bul
            float angle = Vector3.SignedAngle(forwardDirection, wallNormal, mainCamera.transform.up);

            // Eðer açý pozitifse oyuncu saða, negatifse sola dönsün
            float targetRotationY = angle > 0 ? 90f : -90f;

            // Oyuncunun yüzünü diðer tarafa döndürecek hedef rotasyonu hesapla
            targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);

            // Dönme iþlemini baþlat
            isTurning = true;
        }
    }
}
