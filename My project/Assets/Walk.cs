using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class Walk : ActionTask{

		public Transform pointA;
		public Transform pointB;
		public Transform characterTransform;
		public float distanceToSwitchTargets = 0.5f;
		public float speed = 0.25f;

		private bool targetingPointA = false;
		private bool targetingPointB = true;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			if (characterTransform == null)
			{
				Debug.LogError("Cannot initiate patrol state, character has not been set.");
				return "";
			}
			else if (pointA == null)
			{
				Debug.LogError("Cannot initiate patrol state, character[" + characterTransform.gameObject.name + "] has nothing set for point A.");
				return "";
			}
			else if (pointB == null)
			{
				Debug.LogError("Cannot initiate patrol state, character[" + characterTransform.gameObject.name + "] has nothing set for point B.");
				return "";
			}

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			float distanceToA = Vector3.Distance(pointA.position, characterTransform.position);
			float distanceToB = Vector3.Distance(pointB.position, characterTransform.position);

			if (distanceToA < distanceToB)
			{
				targetingPointA = true;
				targetingPointB = false;
			}
			else
			{
				targetingPointA = false;
				targetingPointB = true;
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			Vector3 currentTargetWayPoint;
			if (targetingPointA)
			{
				currentTargetWayPoint = pointA.position;
			}
			else
			{
				currentTargetWayPoint = pointB.position;
			}
			Vector3 directionToTarget = (currentTargetWayPoint - characterTransform.position).normalized;
			characterTransform.position += directionToTarget * speed;

			float distanceToTarget = Vector3.Distance(currentTargetWayPoint, characterTransform.position);
			if (distanceToTarget < distanceToSwitchTargets)
			{
				if (targetingPointA)
				{
					targetingPointB = true;
					targetingPointA = false;
				}
				else if (targetingPointB)
				{
					targetingPointB = false;
					targetingPointA = true;
				}
			}
		}

		//Called when the task is disabled.
		protected override void OnStop()
		{

		}

		//Called when the task is paused.
		protected override void OnPause()
		{

		}
	}
}