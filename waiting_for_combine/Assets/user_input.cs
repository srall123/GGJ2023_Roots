using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_input : MonoBehaviour
{
	public bool input_chosen;
	public bool input_active;
	public float shoot_force;
	public int x;  //to delete
	// for powerbar
	// public GameObject ballPrefab;
    public Transform firePos;
    public UnityEngine.UI.Slider powerSlider;
    public TMPro.TextMeshProUGUI sliderText;
    public AudioSource shootingAudio;
    public AudioClip fireClip;
    public AudioClip chargingClip;
    public float minForce = 1f;
    public float maxForce = 20f;
    public float chargingTime = 1f;//1.0f만큼 차징되는데 0.5초가 걸리도록 설정.

    public float currentForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable()
    {
        currentForce = minForce;
        powerSlider.value = minForce;
        fired = false;
    }

    void Start()
    {
		chargeSpeed = (maxForce - minForce) / chargingTime;
		input_chosen = false;
		input_active = true;
		shoot_force = 0f;
    }

    public void ChangeSlider()
    {
        sliderText.text = powerSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		if (input_active == true)
		{
			if (fired == true)
				return; //한번이라도 발사되면 끝
			if (currentForce >= maxForce && !fired)
				currentForce = minForce;
			else if (Input.GetKeyDown(KeyCode.Space))
			{
				currentForce = minForce;//(minForce 최소 힘부터 시작)
				Debug.Log("You have pressed Space!");
				shootingAudio.clip = chargingClip;
				shootingAudio.Play();
			}
			else if (Input.GetKey(KeyCode.Space) && !fired)
			{
				Debug.Log("You are pressing space now!");
				currentForce += chargeSpeed * Time.deltaTime;
				// Debug.Log(currentForce);
				powerSlider.value = currentForce;
				shoot_force = currentForce;
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

	private void Fire()
	{
		fired = true;
		fired = false;
	}
}
