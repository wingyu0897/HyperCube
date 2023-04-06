using UnityEngine;
using DG.Tweening;

public class MovingBoxLevel : Level
{
	[SerializeField]
	private Transform box;

	private Vector3 originPos;

	public override void Initialize()
	{
		originPos = box.transform.position;
		box.transform.DOKill();
	}

	public override void OnSpawn()
	{
		box.transform.DOKill();
		bool isRight = Random.Range(0, 2) > 0 ? true : false;
		box.transform.position = new Vector3(isRight ? 3f : -3f, originPos.y);
		box.transform.DOMoveX(isRight ? -3f : 3f, 6f);
	}
}
