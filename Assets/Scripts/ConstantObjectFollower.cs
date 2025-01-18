using UnityEngine;

namespace BatuDev.General
{
	public class ConstantObjectFollower : ObjectFollower
	{
		public bool alignRotation;
		public Vector3 rotationAlignOffset;
		
		private void Awake() {
			FollowLerpAmount = 1f;
		}

		private void Update() {
			if (alignRotation) {
				transform.rotation = Quaternion.Euler(rotationAlignOffset + objectToFollow.rotation.eulerAngles);
			}
		}
	}
}