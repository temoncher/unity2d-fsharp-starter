namespace CoreScripts

open UnityEngine

type Cargo =
    | Empty
    | Full of string

type PackageDeliverer() =
    inherit MonoBehaviour()

    let mutable cargo = Empty

    member private this.OnTriggerEnter2D(other: Collider2D) =
        match other.tag with
        | "Package" ->
            match cargo with
            | Empty ->
                cargo <- Full "Some package"
                Object.Destroy(other.gameObject)
            | Full _ -> Debug.Log("You already picked up a package")
        | "Customer" ->
            match cargo with
            | Full _ ->
                cargo <- Empty
                Object.Destroy(other.gameObject)
            | Empty -> Debug.Log("You have no package to deliver")
        | _ -> ()
