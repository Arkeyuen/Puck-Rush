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
            // Oyuncunun yava��a d�nmesi i�in rotasyonu yumu�at
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            // Hedef rotasyona yakla�t�k�a d�nme i�lemini bitir
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isTurning = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // E�er �arp��ma duvarla ger�ekle�tiyse
        if (collision.gameObject.CompareTag("SoftWall"))
        {
            // Oyuncunun y�z�ne �arpan duvar�n normal vekt�r�n� al
            Vector3 wallNormal = collision.contacts[0].normal;

            // Kamera y�n�ne g�re yatay d�zlemde duvar�n normalini d�zelt
            Camera mainCamera = Camera.main;
            wallNormal = Vector3.ProjectOnPlane(wallNormal, mainCamera.transform.up);

            // Y�z�n d�nme y�n�n� belirlemek i�in oyuncunun ileri do�ru vekt�r�n� al
            Vector3 forwardDirection = transform.forward;

            // Duvar�n normal vekt�r� ve oyuncunun ileri do�ru vekt�r� aras�ndaki a��y� bul
            float angle = Vector3.SignedAngle(forwardDirection, wallNormal, mainCamera.transform.up);

            // E�er a�� pozitifse oyuncu sa�a, negatifse sola d�ns�n
            float targetRotationY = angle > 0 ? 90f : -90f;

            // Oyuncunun y�z�n� di�er tarafa d�nd�recek hedef rotasyonu hesapla
            targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);

            // D�nme i�lemini ba�lat
            isTurning = true;
        }
    }
}
