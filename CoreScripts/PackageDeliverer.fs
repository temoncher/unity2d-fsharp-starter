namespace CoreScripts

open UnityEngine

type Cargo =
    | Empty
    | Full of string

type PackageDeliverer() =
    inherit MonoBehaviour()

    let defaultColor = Color(1f, 1f, 1f, 1f)

    let mutable cargo = Empty

    let mutable _spriteRenderer: SpriteRenderer = null

    member private this.Start() =
        _spriteRenderer <- this.GetComponent<SpriteRenderer>()

    member private this.OnTriggerEnter2D(other: Collider2D) =
        match other.tag with
        | "Package" -> this._tryPickupPackage other
        | "Customer" -> this._tryDeliverPackage other
        | _ -> ()

    member private this._tryPickupPackage(packageCollider: Collider2D) =
        match cargo with
        | Empty ->
            let package = packageCollider.GetComponent<Package>()

            let packageColor =
                packageCollider
                    .GetComponent<SpriteRenderer>()
                    .color

            cargo <- Full(package.contents)
            _spriteRenderer.color <- packageColor
            Object.Destroy(packageCollider.gameObject)
        | Full _ -> Debug.Log("You already picked up a package")

    member private this._tryDeliverPackage(customerCollider: Collider2D) =
        match cargo with
        | Full _ ->
            cargo <- Empty
            _spriteRenderer.color <- defaultColor
            Object.Destroy(customerCollider.gameObject)
        | Empty -> Debug.Log("You have no package to deliver")
