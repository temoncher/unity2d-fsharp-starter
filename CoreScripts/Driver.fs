namespace CoreScripts

open UnityEngine

type Driver() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let _steerSpeed = 350f

    [<SerializeField>]
    let _moveSpeed = 10f


    member private this.Update() =
        this._applyMovement ()
        this._applySteering ()

    member private this._applyMovement() =
        let moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime

        Vector3(0f, moveAmount, 0f)
        |> this.transform.Translate

    member private this._applySteering() =
        let steerAmount =
            Input.GetAxis("Horizontal") * -1f * _steerSpeed * Time.deltaTime

        Vector3(0f, 0f, steerAmount)
        |> this.transform.Rotate
