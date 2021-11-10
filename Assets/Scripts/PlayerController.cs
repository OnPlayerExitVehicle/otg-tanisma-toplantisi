using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueBaseClass;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private DialogueHolder dialogueHolder;
    private bool facingRight;
    private float lastHeight;
    private bool isSliding = false;
    private bool isFalling = true;
    private int skidNumber = 0;
    private bool isJumping = false;
    private Dictionary<int, Tuple<string, string>> dictionary;

    [SerializeField] private int jumpForce;

    private Animator animator;
    private Rigidbody2D rigidbody;
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;
        dictionary = new Dictionary<int, Tuple<string, string>>()
        {
            {0, new Tuple<string, string>("Oyun Tasarım ve Geliştirme Topluluğu", "Oyun Tasarım ve Geliştirme Topluluğu 2019 yılında Sakarya Üniversitesi'nde kuruldu.\ninstagram.com/sauotg\n")},
            {1, new Tuple<string, string>("Ali Nazif Koca", "Topluluk Başkanı\nonplayerexitvehicle@outlook.com")},
            {2, new Tuple<string, string>("Hasan Keskintaş", "Kurucu Üye - Topluluk Başkan Yardımcısı")},
            {3, new Tuple<string, string>("Mert Harmankaşı", "Yönetim Üyesi")},
            {4, new Tuple<string, string>("Şeyma Altıparmak", "Yönetim Üyesi")},
            {5, new Tuple<string, string>("Zeynep İrem Tekin", "Yönetim Üyesi")},
            {6, new Tuple<string, string>("Kimlere Açığız?", "-Oyun Geliştiriciler\n-2D/3D Artist'ler\n-Bölüm Tasarımcıları\n-Hikaye Yazarları\n-Animasyoncular")},
            {7, new Tuple<string, string>("Ne Yapacağız?", "-Ekip oluşturma\n-Eğitimler\n-Game Jam organizasyonları\n")},
            {8, new Tuple<string, string>("Dünyada Oyun Sektörü", "2020 yılında dünya çapında oyundan elde edilen gelir film ve spor sektörlerinin toplam gelirine eşitti.")},
            {9, new Tuple<string, string>("Türkiye'de Oyun Sektörü", "Dünya genelinde oyun oynamak için cep telefonu tercih edenlerin oranında Türkiye %55 ile ilk sırada. Yine aynı ankette telefonda günde en az 1 kere oyun oynayanların oranında Türkiye %49'la birinci.")},
            {10, new Tuple<string, string>("Bize Katılın", "Topluluğumuzu büyütmek için siz değerli üyelerimize ihtiyacımız var.\n-Sponsorluk Koordinatörü\n-Ekip Koordinatörü\n-Etkinlik Koordinatörü\n-Sosyal Medya Sorumlusu\nVeya aklınıza gelen herhangi bir şey :)")},
            {11, new Tuple<string, string>("The End", "Bize katıldığınız için teşekkür ederiz :)")}
            
        };
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Terrain") || other.gameObject.CompareTag("Skid"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("QuestionMark") && other.transform.position.y > transform.position.y)
        {
            int index = Convert.ToInt32(other.gameObject.name);
            dialogueHolder.StartDialogue(dictionary[index].Item1, dictionary[index].Item2);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Skid"))
        {
            skidNumber++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Skid"))
        {
            skidNumber--;
        }
    }

    void Update()
    {
        if (skidNumber > 0)
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Slide");
        }
        else
        {
            animator.SetTrigger("Idle");
            animator.ResetTrigger("Slide");
        }

        if (Input.GetAxis("Horizontal") > .1f)
        {
            if (!facingRight)
            {
                FlipRight();
            }
            transform.position = new Vector3(transform.position.x + (Time.deltaTime * speed), transform.position.y, transform.position.z);
            animator.SetTrigger("Walk");
        }
        else
        {
            if (Input.GetAxis("Horizontal") < -.1f)
            {
                if (facingRight)
                {
                    FlipLeft();
                }

                transform.position = new Vector3(transform.position.x - (Time.deltaTime * speed), transform.position.y,
                    transform.position.z);
                animator.SetTrigger("Walk");
            }
            else
            {
                animator.ResetTrigger("Walk");
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (!isJumping)
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
            
        }

        if (Input.GetKey(KeyCode.Backspace) && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        /*
        if(Input.GetKeyDown(KeyCode.E)){
            dialogueHolder.StartDialogue("asd", "asdasdasda");
        }
        */
    }

    void LateUpdate()
    {
        lastHeight = transform.position.y;
    }

    private void FlipRight()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        facingRight = true;
    }

    private void FlipLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        facingRight = false;
    }
}
