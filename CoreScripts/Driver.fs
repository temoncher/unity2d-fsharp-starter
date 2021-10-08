namespace CoreScripts

open UnityEngine
open System

type Driver() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let _steerSpeed = 350f

    [<SerializeField>]
    let _moveSpeed = 10f

    let getMoveAmount = (*) _moveSpeed

    let getSteerAmount = (*) (_steerSpeed * -1f)

    member private this.FixedUpdate() = this._applyMovement ()

    member private this._applyMovement() =
        let moveAmount =
            Input.GetAxis("Vertical") * Time.fixedDeltaTime
            |> getMoveAmount

        let steerAmount =
            Input.GetAxis("Horizontal") * Time.fixedDeltaTime
            |> getSteerAmount

        Vector3(0f, moveAmount, 0f)
        |> this.transform.Translate

        Vector3(0f, 0f, steerAmount)
        |> this.transform.Rotate
