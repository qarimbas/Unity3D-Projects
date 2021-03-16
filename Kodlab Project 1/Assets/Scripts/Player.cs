using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;
    private int skor;
    public Text toplamSkor;

    [SerializeField]
    private GameObject anahtarVar;

    [SerializeField]
    private float hiz;
    private bool sagaBak;

    // Start is called before the first frame update
    void Start()
    {
        sagaBak = true;
        skor = 0;

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");

        TemelHareketler(yatay);
        YonCevir(yatay);
    }

    private void TemelHareketler(float yatay)
    {
        myRigidbody.velocity = new Vector2(yatay * hiz, myRigidbody.velocity.y);

        myAnimator.SetFloat("karakterHizi", Mathf.Abs(yatay));
    }

    private void YonCevir(float yatay)
    {
        if (yatay > 0 && !sagaBak || yatay < 0 && sagaBak)
        {
            sagaBak = !sagaBak;
            Vector3 yon = transform.localScale;

            yon.x *= -1;

            transform.localScale = yon;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "altin")
        {
            other.gameObject.SetActive(false);
            skor += 100;
            SkorAyarla(skor);
        }

        if(other.gameObject.tag == "anahtar")
        {
            other.gameObject.SetActive(false);

            anahtarVar.SetActive(true);
        }
    }

    void SkorAyarla(int count)
    {
        toplamSkor.text = count.ToString(); //stringe cevirip yazdır
    }
}
