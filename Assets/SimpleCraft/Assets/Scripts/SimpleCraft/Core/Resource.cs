﻿using UnityEngine;

namespace SimpleCraft.Core{
    /// <summary>
    /// A resource has items can be gathered by a player
    /// Author: Raul Souza
    /// </summary>
    public class Resource : MonoBehaviour{

        [SerializeField]
        private Item _item;

        [SerializeField]
        private AudioSource _gatherSound;

        //private Item _ItemScript { get; set; }
		public Item Item {
			get { return _item; }
			set { _item = value; }
		}

		[SerializeField] private float _amount;
		public float Amount {
			get { return _amount; }
			set { _amount = value; }
		}

		void Start(){
            if (this.gameObject.tag != "Resource")
                Debug.Log(this.name + " has a Resource script but isn't tagged as Resource!");
        }

        /// <summary>
        /// Called when the player uses a tool on this resource
        /// returns the amount of resource gathered
        /// </summary>
        /// <param name="AmountTaken">Amount taken.</param>
        public float Gather(float AmountTaken){
			if (_amount < AmountTaken)
				AmountTaken = _amount;
			
			_amount -= AmountTaken;

			if (_amount <= 0)
				Destroy (this.gameObject);
            if(_gatherSound!=null)
                _gatherSound.Play();

			return AmountTaken;
		}
	}
}