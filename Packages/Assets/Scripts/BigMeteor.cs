using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : MonoBehaviour
{
    private int hitCount = 0;

    AudioSource audioSource;
    public ObjectDestroyed objectDestroyed;
    CameraZoom cameraZoom;
    CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        objectDestroyed = FindObjectOfType<ObjectDestroyed>();
        cameraZoom = FindObjectOfType<CameraZoom>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }

        if (hitCount >= 5)
        {
            cameraZoom.AdjustZoom(cameraZoom.virtualCamera.m_Lens.FieldOfView - 20.0f);
            cameraShake.ShakeCamera();
            Destroy(this.gameObject);
            objectDestroyed.PlayExplosion();
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            cameraShake.ShakeCamera();
            objectDestroyed.PlayExplosion();
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
