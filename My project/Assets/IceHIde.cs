using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class IceHIde : ActionTask{

		public Transform targetObject;
		public float moveSpeed = 5.0f;
		private Rigidbody rb;

		public GameObject sprite;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){

			rb = sprite.GetComponent<Rigidbody>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute(){
			sprite.GetComponent<Renderer>().material.color = Color.blue;
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{


			

			Vector3 direction = (targetObject.position - sprite.transform.position).normalized;
			rb.velocity = direction * moveSpeed;

			//// Keep the object behind the target object
			//if (Vector3.Distance(sprite.transform.position, targetObject.position) < 0.5f)
			//{
			//	sprite.transform.position = targetObject.position - direction;
			//	Debug.Log("Stopped moving");
			//}
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}