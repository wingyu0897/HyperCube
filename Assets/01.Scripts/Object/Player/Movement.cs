using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField]
	private float forwardSpeed;
	public float ForwardSpeed { get => forwardSpeed; set => forwardSpeed = value; }
    [SerializeField]
    private float sidewardMaxSpeed;
	public float SidewardMaxSpeed { get => sidewardMaxSpeed; set => sidewardMaxSpeed = value; }
	[SerializeField]
	private float acceleration = 1f;
	public float Acceleration { get => acceleration; set => acceleration = value; }
	[SerializeField]
	private float deAcceleration = 1f;

	[Header("Reference")]
	[SerializeField]
	private GameObject tabToStart;
	[SerializeField] 
	private Slider sidewardSlider;
	[SerializeField]
	private ParticleSystem deathParticle;

	private TrailRenderer trailRenderer;

	public bool move = false;
    public Vector3 curVelocity;
	public bool isDie = false;

	[Header("Event")]
	public UnityEvent OnDie;

	private void Awake()
	{
		trailRenderer = GetComponent<TrailRenderer>();
	}

	private void Update()
	{
		if (move)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (sidewardSlider.value != 0)
				{
					sidewardSlider.value = sidewardSlider.value > 0 ? -1f : 1f;
				}
				else
				{
					sidewardSlider.value = Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f ? 1f : -1f;
				}
			}
			SidewardVelocity(sidewardSlider.value);
			Move();
		}
	}

	private void SidewardVelocity(float input)
	{
		float addVelocity = 0;
		if (input < 0)
		{
			addVelocity = input;
		}
		else if (input > 0)
		{
			addVelocity = input;
		}
		else
		{
			addVelocity = 0;
		}
		curVelocity = new Vector3(curVelocity.x += addVelocity * Time.deltaTime * acceleration, forwardSpeed, 0);
		curVelocity = new Vector3(Mathf.Clamp(curVelocity.x, -sidewardMaxSpeed, sidewardMaxSpeed), forwardSpeed);
	}

	private void Move()
	{
		transform.Translate(curVelocity * Time.deltaTime);
	}

	IEnumerator SlowlyStop()
	{
		float forwardSpeed = this.forwardSpeed;

		while (forwardSpeed > 0)
		{
			transform.Translate(new Vector3(0, forwardSpeed) * Time.deltaTime);
			forwardSpeed -= Time.deltaTime * deAcceleration;
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}

	public void Die()
	{
		if (!isDie)
		{
			StartCoroutine(SlowlyStop());
			CinemachineShake.Instance.ShakeCamera(2f, 0.2f);

			move = false;
			trailRenderer.enabled = false;
			isDie = true;
			curVelocity = Vector3.zero;
			GetComponent<SpriteRenderer>().enabled = false;
			deathParticle.Play();
			OnDie?.Invoke();
		}
	}

	public void Active(bool active)
	{
		tabToStart.SetActive(!active);
		move = active;
		trailRenderer.Clear();
		trailRenderer.enabled = active;
	}

	public void Initialize()
	{
		StopAllCoroutines();
		Active(false);
		isDie = false;
		curVelocity = Vector3.zero;
		sidewardSlider.value = 0;
		transform.position = new Vector3(0, -2.5f);
		GetComponent<SpriteRenderer>().enabled = true;
		deathParticle.Clear();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Wall"))
		{
			Die();
			GameManager.Instance?.UpdateState(GameState.Result);
		}
	}
}
