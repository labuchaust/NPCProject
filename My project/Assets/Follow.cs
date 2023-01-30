using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class Follow : ActionTask{

		public Transform playerTransform;
		public Transform objectTransform;
		private float speed = 5f;
		public GameObject sprite;


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
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate(){

			//makes the object follow player
			objectTransform.position = Vector3.MoveTowards(objectTransform.position, playerTransform.position, speed * Time.deltaTime);

		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}