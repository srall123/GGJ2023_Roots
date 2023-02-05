using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_input : MonoBehaviour
{
	public bool input_chosen;
	public bool input_active;
	public int force;
	public int x;  //to delete
	// for powerbar
	// public GameObject ballPrefab;
    public Transform firePos;
    public UnityEngine.UI.Slider powerSlider;
    public TMPro.TextMeshProUGUI sliderText;
    public AudioSource shootingAudio;
    public AudioClip fireClip;
    public AudioClip chargingClip;
    public float minForce = 10f;
    public float maxForce = 100f;
    public float chargingTime = 0.5f;

    public float currentForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable()
    {
        currentForce = minForce;
        //powerSlider.GetComponent<UnityEngine.UI.Slider>().value;
        powerSlider.value = minForce;
        Debug.Log(powerSlider.value);
        fired = false;
    }

    public void ChangeSlider()
    {
        sliderText.text = powerSlider.value.ToString();
    }

    void Start()
    {
		chargeSpeed = (maxForce - minForce) / chargingTime;
		input_chosen = false;
		input_active = true;
		force = 0;

    }

    private void Fire()
    {
        fired = true;
        currentForce = minForce;
        powerSlider.value = currentForce;
        fired = false;
    }

    void Update()
    {
		if (input_active == true)
		{
			if (fired == true)
				return;
			if (currentForce >= maxForce && !fired)
				currentForce = minForce;
			else if (Input.GetKeyDown(KeyCode.Space))
			{
				currentForce = minForce;
				Debug.Log("You have pressed Space!");
				shootingAudio.clip = chargingClip;
				shootingAudio.Play();
			}
			else if (Input.GetKey(KeyCode.Space) && !fired)
			{
				Debug.Log("You are pressing space now!");
				currentForce += chargeSpeed * Time.deltaTime;
				Debug.Log(currentForce);
				powerSlider.value = currentForce;
				ChangeSlider();
			}
			else if (Input.GetKeyUp("space") && !fired)
			{
				Debug.Log("You have taken your hands from the space!");
				Fire();
				input_chosen = true;
				input_active = false;
			}
		}
    }
}
