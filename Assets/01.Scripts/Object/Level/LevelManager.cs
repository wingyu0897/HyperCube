using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LevelPrefab
{
	public Level prefab;
	public int appearPoint = 0;
	public int disAppearPoint = -1;
}

[RequireComponent(typeof(LevelPoolManager))]
public class LevelManager : MonoBehaviour
{
	[Header("<Pool>")]
	[SerializeField]
	private PoolLevelList poolList;
	private LevelPoolManager poolManager;

	[Header("<Levels>")]
	[SerializeField][Tooltip("������ ������")]
	private List<LevelPrefab> levelPrefabs;
	[SerializeField][Tooltip("���� �Ұ����� ������")]
	private List<LevelPrefab> unUsableLevels;
	[SerializeField][Tooltip("���� ���� ������ ������")]
	private List<LevelPrefab> usableLevels;
	[SerializeField][Tooltip("���� ������ ������")]
	private List<Level> spawnedLevels = new List<Level>();
	[SerializeField][Tooltip("���� �ֱ� ������ ����")]
	private Level lateInput = null;

	[Header("<Spawning>")]
	public bool isRunning = false;
	public bool isStopped = true;
	[SerializeField]
	private int weight = 0;

	[Header("<Setting>")]
	[SerializeField]
	private Vector3 spawnOffset;
	private Vector3 spawnPosition;
	private Vector2 bottomPos;

	private Camera cam;

	private void Awake()
	{
		poolManager = GetComponent<LevelPoolManager>();
		cam = Camera.main;
		bottomPos = cam.ScreenToWorldPoint(new Vector3(0, 0));
	}

	private void Start()
	{
		foreach (Pool pl in poolList.list)
		{
			poolManager.CreatePool(pl.prefab, transform, pl.count);
		}

		spawnPosition = spawnOffset;
	}

	private void Update()
	{
		if (isRunning)
		{
			CheckAppearPoint();
			CheckDisAppearPoint();
			SpawnLevels();
			PushLevels();

			spawnPosition = cam.transform.position + spawnOffset;
			spawnPosition.z = 0;
		}
	}
	/// <summary>
	/// ������ �����ϴ� �Լ�.
	/// </summary>
	private void SpawnLevels()
	{
		if (usableLevels.Count == 0)
			return;

		Level obj;

		if (lateInput != null)
		{
			if (spawnPosition.y - lateInput.transform.position.y >= lateInput.lenght)
			{
				Vector3 lastPos = lateInput.transform.position + new Vector3(0, lateInput.lenght);
				int weightValue = Random.Range(0, weight + 1);
				obj = Pop(WeightToPrefab(weightValue));
				obj.transform.position = lastPos;
			}
		}
		else
		{
			obj = Pop(usableLevels[0].prefab);
			obj.transform.position = spawnPosition;
		}
	}
	/// <summary>
	/// usableLevels�� prefab�� maxWeight�� Ȯ���ϸ� �ش��ϴ� prefab�� ��ȯ�Ѵ�.
	/// </summary>
	/// <param name="weight">����ġ</param>
	/// <returns>usableLevels�� prefab���� �Ű����� ���� ��ġ�ϴ� prefab</returns>
	private Level WeightToPrefab(int weight)
	{
		for (int i = 0; i < usableLevels.Count; i++)
		{
			if (weight <= usableLevels[i].prefab.maxWeight)
			{
				return usableLevels[i].prefab;
			}
		}
		Debug.LogWarning($"�ش� ����ġ <{weight}>�� usableLevels�� ��� ����ġ�� �Ѿ�ϴ�.");
		return usableLevels[0].prefab;
	}
	/// <summary>
	/// ȭ�� ������ ���� ������ ȸ���ϴ� �Լ�.
	/// </summary>
	private void PushLevels()
	{
		if (spawnedLevels.Count > 0)
		{
			Level firLevel = spawnedLevels[0];
			if ((cam.transform.position.y + bottomPos.y) - firLevel.transform.position.y - 1 >= firLevel.lenght)
			{
				Push(firLevel);
			}
		}
	}
	/// <summary>
	/// ������ �����鿡�� ������ ����Ʈ(���ھ�)�� �����ϸ� ���� ������ ����Ʈ�� �ű�� �Լ�.
	/// </summary>
	private void CheckAppearPoint()
	{
		if (unUsableLevels.Count > 0)
		{
			int count = unUsableLevels.Count;
			for (int i = 0; i < count; i++)
			{
				if (unUsableLevels[0].appearPoint <= GameManager.Instance.score)
				{
					usableLevels.Add(unUsableLevels[0]);
					weight += unUsableLevels[0].prefab.weight; //����ġ �� �ջ�
					unUsableLevels[0].prefab.maxWeight = weight; //�ִ� ����ġ �� ����
					unUsableLevels.RemoveAt(0);
				}
			}
		}
	}

	private void CheckDisAppearPoint()
	{
		if (usableLevels.Count > 0)
		{
			int count = usableLevels.Count;
			int index = 0;
			for (int i = 0; i < count; i++)
			{
				if (usableLevels[index].disAppearPoint > 0 && usableLevels[index].disAppearPoint <= GameManager.Instance.score)
				{
					weight -= usableLevels[index].prefab.weight;
					usableLevels.RemoveAt(index);
				}
				else
				{
					index++;
				}
			}
		}
	}

	public void Active()
	{
		isRunning = true;
		isStopped = false;
	}
	/// <summary>
	/// �ʱ�ȭ �Լ�.<br/>
	/// ������ �������� ȸ���Ѵ�.
	/// </summary>
	public void Initialize()
	{
		StopAllCoroutines();

		isRunning = false;
		isStopped = true;
		spawnPosition = spawnOffset;

		int count = spawnedLevels.Count;
		for (int i = 0; i < count; i++)
		{
			Push(spawnedLevels[0]);
		}

		levelPrefabs = levelPrefabs.OrderBy(i => i.appearPoint).ToList(); //levelPrefbs.appearPoint ���� �������� �������� ����
		usableLevels.Clear(); //��밡���� ������ �ʱ�ȭ
		unUsableLevels = levelPrefabs.ToList(); //��� �Ұ����� ������ �ʱ�ȭ(������ �����鿡�� �� ����)

		weight = 0;
		lateInput = null;
	}

	public void StopMove()
	{
		isRunning = false;
		
		if (!isStopped)
		{
			StopAllCoroutines();

			isStopped = true;
		}
	}

	//IEnumerator SlowMove()
	//{
	//	float speed = fallingSpeed;

	//	while (speed > 0.01f)
	//	{
	//		float preSpeed = speed;
	//		speed -= Time.deltaTime * fallingSpeed;

	//		speed = Mathf.Clamp(speed, 0, preSpeed);

	//		foreach (Level lv in spawnedLevels)
	//		{
	//			lv.speed = speed;
	//		}

	//		yield return new WaitForSeconds(Time.deltaTime);
	//	}

	//	foreach (Level lv in spawnedLevels)
	//	{
	//		lv.canMove = false;
	//	}
	//}

	public Level Pop(Level level)
	{
		Level obj = poolManager.Pop(level);
		spawnedLevels.Add(obj);
		lateInput = obj;
		obj.OnSpawn();
		return obj;
	}

	public void Push(Level obj)
	{
		obj.Initialize();
		spawnedLevels.Remove(obj);
		poolManager.Push(obj);
	}

#if UNITY_EDITOR
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(spawnPosition, 0.5f);
		Gizmos.color = Color.white;
	}
#endif
}
