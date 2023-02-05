using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class DecreaseHealth : ActionTask{


		Blackboard blackboard;


		public float maxHealth;
		public float currentHealth;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){

			 maxHealth = blackboard.GetValue<float>("health");

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


			if (Input.GetKeyDown("z"))
			{
				AttackEnemy();
			}
		}


		private void AttackEnemy()
		{
			currentHealth = blackboard.GetValue<float>("health");
			currentHealth--;
			blackboard.SetValue("health", currentHealth);
		}

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}