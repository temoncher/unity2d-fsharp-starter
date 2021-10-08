namespace CoreScripts

open UnityEngine

type CollisionLogger() =
    inherit MonoBehaviour()

    member private this.OnCollisionEnter2D(other: Collision2D) =
        Debug.Log($"Collided with: {other.gameObject.name}")
