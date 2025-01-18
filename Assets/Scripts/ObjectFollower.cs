using UnityEngine;

namespace BatuDev.General
{
	public abstract class ObjectFollower : MonoBehaviour
	{
		public Transform objectToFollow;
		[Space]
		[Space]
		public Vector3 followOffset;
		public bool setFollowOffset;
		[SerializeField] private bool followLocal;
		[Space]
		[Space]
		[SerializeField, Range(0, 1)] protected float followLerpAmount = .5f;
		[SerializeField, Range(0, 1)] protected float rotationLerpAmount = .5f;
		[Space]
		[Space]
		public bool lookAtTarget;

		public bool hardLookAt;

		public bool FollowLocal {
			get => followLocal;
			set => followLocal = value;
		}

		public float FollowLerpAmount {
			get => followLerpAmount;
			set => followLerpAmount = value;
		}

		protected void LateUpdate() {
			if (lookAtTarget) {
				if (hardLookAt) {
					transform.LookAt(objectToFollow);
				} else {
					var tr = transform;
					transform.rotation = Quaternion.Lerp(tr.rotation,
						Quaternion.LookRotation(objectToFollow.position - tr.position), rotationLerpAmount);
				}
			}
			
			if (Mathf.Abs(FollowLerpAmount - 1) < Mathf.Epsilon) {
				if (followLocal) {
					transform.position = objectToFollow.position -
					                     (objectToFollow.forward * followOffset.z +
					                      objectToFollow.right * followOffset.x +
					                      objectToFollow.up * followOffset.y);
				} else {
					transform.position = objectToFollow.position - followOffset;
				}
			} else {
				if (followLocal) {
					transform.position = Vector3.Lerp(transform.position, objectToFollow.position -
					                                                      (objectToFollow.forward * followOffset.z +
					                                                       objectToFollow.right * followOffset.x +
					                                                       objectToFollow.up * followOffset.y),
						FollowLerpAmount);
				} else {
					transform.position = Vector3.Lerp(transform.position, objectToFollow.position - followOffset,
					FollowLerpAmount);
				}
			}
		}

#if UNITY_EDITOR
		private void OnDrawGizmosSelected() {
			if (setFollowOffset) {
				if (followLocal) {
					var diff = objectToFollow.position - transform.position;
					followOffset = objectToFollow.position -
					               (objectToFollow.forward * diff.z +
					                objectToFollow.right * diff.x +
					                objectToFollow.up * diff.y);
				} else {
					followOffset = objectToFollow.position - transform.position;
				}
			}
		}
#endif
	}
}