using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	public class Attack : ActionTask{


		public Transform playerTransform;
		public Transform objectTransform;
		private float speed = 5f;
		public GameObject sprite;
		float radius;
		public float distance = 2f;





		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise


		protected override string OnInit(){

			//find player with tag
			playerTransform = GameObject.FindWithTag("Player").transform;
			objectTransform = sprite.GetComponent<Transform>();



			//objectTransform = playerTransform;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
			//objectTransform.position = Vector3.MoveTowards(objectTransform.position, playerTransform.position, speed * Time.deltaTime);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){
			//makes the object follow player


			Vector3 targetPos = playerTransform.transform.position;
			Vector3 currentPos = sprite.transform.position;
			Vector3 direction = targetPos - currentPos;
			float distanceToTarget = direction.magnitude;
			sprite.GetComponent<Renderer>().material.color = Color.blue;

			if (distanceToTarget > distance)
			{
				direction = direction.normalized;
				sprite.transform.position = currentPos + direction * speed * Time.deltaTime;
			}


			//check for player collision

			if (CheckForPlayerCollision())
            {
				DecreasePlayerHealth();
			}

           
			//if (firecurrenthealth <= 0)
			//{
			//	Die();
			//}

			



		}

		

		private bool CheckForPlayerCollision()
		{
			Collider[] colliders = Physics.OverlapSphere(objectTransform.position, radius);
			foreach (Collider collider in colliders)
			{
				if (collider.CompareTag("Player"))
				{
					return true;
				}
			}
			return false;
		}


		private void DecreasePlayerHealth()
		{
			// Find the player's health script and decrease their health
			PlayerController playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
			playerHealth.currentHealth--;
		}

		private Collider[] PhysicsOverlapSphere(Vector3 position, Transform transform, Transform playerTransform)
        {
            throw new NotImplementedException();
        }

        //Called when the task is disabled.
        protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}