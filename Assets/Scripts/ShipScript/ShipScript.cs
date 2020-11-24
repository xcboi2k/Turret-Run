 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipScript : MonoBehaviour
{
    public static ShipScript instance;

    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private Animator animate;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pointClip, flyClip, explodeClip;

    private float forwardSpeed = 3f;
    private float speedupSpeed = 4f;

    private bool didSpeed;
    public bool isAlive;

    private Button speedButton;
    public int score;

    void Awake(){
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;
        score = 0;
        
        speedButton = GameObject.FindGameObjectWithTag("SpeedButton").GetComponent<Button>();
        speedButton.onClick.AddListener(() => SpeedUpShip());

        SetCameraX();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didSpeed)
            {
                didSpeed = false;
                myRigidBody.velocity = new Vector2(0,speedupSpeed);
                animate.SetTrigger("SpeedUp");
            }

            if(myRigidBody.velocity.y >= 0){
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0,-90,-myRigidBody.velocity.y/7);
                transform.rotation = Quaternion.Euler(0,0,angle);
            }
        }
    }

    void SetCameraX(){
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x)-1;
    }
    public float GetPositionX(){
        return transform.position.x;
    }
    public void SpeedUpShip(){
        didSpeed = true;
        audioSource.PlayOneShot(flyClip);
    }

    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Ground" || target.gameObject.tag == "Turret"){
            if(isAlive){
                isAlive = false;
                animate.SetTrigger("Burn");
                GameplayController.instance.PlayerDiedShowScore(score);
                audioSource.PlayOneShot(explodeClip);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "TurretHolder"){
            score++;
            GameplayController.instance.SetScore(score);
            audioSource.PlayOneShot(pointClip);

        }
    }
}
