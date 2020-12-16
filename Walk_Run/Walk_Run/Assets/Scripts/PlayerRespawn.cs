using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public FloatData value;
    public GameObject spawnPoint;
    [SerializeField] private CharacterController myCharacterControllerScript;
    private ClampFloatData healthClamp;

    private void Start()
    {
        myCharacterControllerScript = GetComponent<CharacterController>();
        healthClamp = GetComponent<ClampFloatData>();
    }

    private void Update()
    {
        if (value.value <=0f)
        {
            myCharacterControllerScript.enabled = false;
            healthClamp.enabled = false;
            transform.position = spawnPoint.transform.position;

            if (transform.position == spawnPoint.transform.position)
            {
                healthClamp.enabled = true;
                myCharacterControllerScript.enabled = true;
                value.value = 50f;
            }
        }
    }
}
