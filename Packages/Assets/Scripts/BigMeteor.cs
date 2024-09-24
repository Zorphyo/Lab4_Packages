using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : MonoBehaviour
{
    private int hitCount = 0;

    AudioSource audioSource;
    public ObjectDestroyed objectDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        objectDestroyed = FindObjectOfType<ObjectDestroyed>();
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
            objectDestroyed.PlayExplosion();
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
