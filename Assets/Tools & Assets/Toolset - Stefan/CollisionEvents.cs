using UnityEngine;

namespace SilverRogue.Tools
{
    /// <summary>
    /// Used to be able to subscribe to a collider's collision events.
    /// </summary>
    public class CollisionEvents : MonoBehaviour
    {
        public event System.Action<Collider> OnTriggerEnterEvent = delegate { };
        public event System.Action<Collider> OnTriggerStayEvent = delegate { };
        public event System.Action<Collider> OnTriggerExitEvent = delegate { };

        public event System.Action<Collision> OnCollisionEnterEvent = delegate { };
        public event System.Action<Collision> OnCollisionStayEvent = delegate { };
        public event System.Action<Collision> OnCollisionExitEvent = delegate { };

        public event System.Action<Collider2D> OnTriggerEnter2DEvent = delegate { };
        public event System.Action<Collider2D> OnTriggerStay2DEvent = delegate { };
        public event System.Action<Collider2D> OnTriggerExit2DEvent = delegate { };

        public event System.Action<Collision2D> OnCollisionEnter2DEvent = delegate { };
        public event System.Action<Collision2D> OnCollisionStay2DEvent = delegate { };
        public event System.Action<Collision2D> OnCollisionExit2DEvent = delegate { };

        public event System.Action<ControllerColliderHit> ControllerColliderHitEvent = delegate { };

        protected void OnTriggerEnter(Collider collider)
        {
            OnTriggerEnterEvent(collider);
        }

        protected void OnTriggerExit(Collider collider)
        {
            OnTriggerExitEvent(collider);
        }

        protected void OnTriggerStay(Collider collider)
        {
            OnTriggerStayEvent(collider);
        }

        protected void OnTriggerEnter2D(Collider2D collider)
        {
            OnTriggerEnter2DEvent(collider);
        }

        protected void OnTriggerExit2D(Collider2D collider)
        {
            OnTriggerExit2DEvent(collider);
        }

        protected void OnTriggerStay2D(Collider2D collider)
        {
            OnTriggerStay2DEvent(collider);
        }

        protected void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterEvent(collision);
        }

        protected void OnCollisionStay(Collision collision)
        {
            OnCollisionStayEvent(collision);
        }

        protected void OnCollisionExit(Collision collision)
        {
            OnCollisionExitEvent(collision);
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter2DEvent(collision);
        }

        protected void OnCollisionStay2D(Collision2D collision)
        {
            OnCollisionStay2DEvent(collision);
        }

        protected void OnCollisionExit2D(Collision2D collision)
        {
            OnCollisionExit2DEvent(collision);
        }

        protected void OnControllerColliderHit(ControllerColliderHit collider)
        {
            ControllerColliderHitEvent(collider);
        }
    }
}
