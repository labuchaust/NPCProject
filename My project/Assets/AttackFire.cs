using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	public class AttackFire : ActionTask{
		public GameObject target; // the GameObject to follow
		public float distance = 2f; // distance to keep from the target
		public float speed = 5f; // speed of movement
		public GameObject sprite;



		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise


		protected override string OnInit()
		{

			


			//objectTransform = playerTransform;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			//objectTransform.position = Vector3.MoveTowards(objectTransform.position, playerTransform.position, speed * Time.deltaTime);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{


			Vector3 targetPos = target.transform.position;
			Vector3 currentPos = sprite.transform.position;
			Vector3 direction = targetPos - currentPos;
			float distanceToTarget = direction.magnitude;

			if (distanceToTarget > distance)
			{
				direction = direction.normalized;
				sprite.transform.position = currentPos + direction * speed * Time.deltaTime;
			}
			sprite.GetComponent<Renderer>().material.color = Color.cyan;




			//if (firecurrenthealth <= 0)
			//{
			//	Die();
			//}





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