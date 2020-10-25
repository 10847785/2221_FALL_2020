using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merge : MonoBehaviour
{
    // Movement
    private FloatData moveSpeed;
    public FloatData normalSpeed, fastSpeed;
    public float rotateSpeed = 30f, gravity = -9.81f, jumpForce = 3f;

    private CharacterController controller;
    private Vector3 movement;
    private float yVar;
    private bool canMove = true;
    
    public IntData playerJumpCount;
    private int jumpCount;
    
    //Trigger Volumes
    public Color newColor;
    public Color defaultColor;
    private MeshRenderer colorChange;

    public bool isOpen;
    private WaitForSeconds wfs;
    public int holdTime = 3;
    public GameObject door;
    public TimerUI timer;
    
    //TimerUI
    public int maxTime;
    public IntData time;
    public Text timerText;
    
    //Shooting
    public int ammoCount = 10;
    public int maxAmmo = 10;
    public GameObject prefab;
    public Transform Instancer;
    public float reloadTime;
    //public WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    public Image coolDownImage;
    private bool canShoot = true;
    
    //Bullet Behaviour
    private Rigidbody rBody;
    public float bulletForce;
    public float lifeTime;
    
    //Health
    public float healthAmount = 20f;
    public FloatData playerHealth, maximumHealth;
    
    //Respawn
    public FloatData value, maxHealth;
    public GameObject spawnPoint;
    private ClampFloatData healthClamp;
    [SerializeField] private CharacterController myCharacterControllerScript;

    private IEnumerator Start()
    {
        //Movement
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
        StartCoroutine(Move());
        
        //Trigger Volumes
        colorChange = GetComponent<MeshRenderer>();
        colorChange.material.color = defaultColor;
        
        wfs = new WaitForSeconds(holdTime);
        
        //TimerUI
        time.value = maxTime;
        
        //Shooting
        coolDownImage.fillAmount = 0;
        ammoCount = maxAmmo;
        
        //Bullet Behaviour
        rBody = GetComponent<Rigidbody>();
        
        rBody.AddRelativeForce(Vector3.forward*bulletForce);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        
        //Respawn
        myCharacterControllerScript = GetComponent<CharacterController>();
        healthClamp = GetComponent<ClampFloatData>();
    }
    
    //Movement
    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            yield return wffu;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = fastSpeed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = normalSpeed;
            }

            if (controller.isGrounded && movement.y < 0)
            {
                yVar = -1f;
            }
            
            if (controller.isGrounded && movement.y < 0)
            {
                yVar = -1f;
                jumpCount = 0;
            }

            if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
            {
                yVar = jumpForce;
                jumpCount++;
            }
        
            var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
            transform.Rotate(0, hInput, 0);
            var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
            movement.Set(vInput, yVar, 0);

            movement = transform.TransformDirection(movement);
            controller.Move(movement * Time.deltaTime);
            yVar += gravity * Time.deltaTime;
        }
        
    }
    
    //TimerUI
    public IEnumerator Countdown()
    {
        time.value = maxTime;
        while (time.value >= 0)
        {
            DisplayTimer();
            yield return new WaitForSeconds(1f);
            time.value--;
        }
    }
    
    private void DisplayTimer()
    {
        timerText.text = time.value.ToString();
    }
    
    //Trigger Volumes
    private void OnTriggerEnter(Collider other)
    {
        newColor.a = 0.5f;
        colorChange.material.color = newColor;
        
        door.SetActive(false);
        
        //Health
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The damage is " + healthAmount);
            playerHealth.value += healthAmount;
            playerHealth.value = Mathf.Clamp(playerHealth.value, 0f, maximumHealth.value);
        }
        
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        colorChange.material.color = defaultColor;
       
        StartCoroutine(timer.Countdown());
        yield return wfs;
        isOpen = false;
        door.SetActive(true);
    }
    
    private void Update()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.LeftShift) && ammoCount > 0 && canShoot)
        {
            fire();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }
        
        //Respawn
        if (value.value <=0f)
        {
            myCharacterControllerScript.enabled = false;
            healthClamp.enabled = false;
            transform.position = spawnPoint.transform.position;

            if (transform.position == spawnPoint.transform.position)
            {
                healthClamp.enabled = true;
                myCharacterControllerScript.enabled = true;
            }
        }
    }
    
    //Shooting
    private void fire()
    {
        Instantiate(prefab, Instancer.position, Instancer.rotation);
        ammoCount--;
        
        if (ammoCount == 0)
        {
            StartCoroutine(reload());
        }
    }
    
    private IEnumerator reload()
    {
        canShoot = false;
        var countDown = reloadTime;
        while (countDown > 0)
        {
            yield return wffu;
            countDown -= .01f;
            countDown = countDown - .01f;
            coolDownImage.fillAmount = countDown / reloadTime;
        }
        ammoCount = maxAmmo;
        canShoot = true;
    }
    
    
    //Clamp Float
    public void onEnable()
    {
        playerHealth.value = maximumHealth.value;
    }
    
    
}
