module Tests
open Xunit


let countFruitInRange startHouseLocationendHouseLocation endHouseLocation treeLocation fruits =
    fruits
    |> Array.filter (fun f -> f + treeLocation >= startHouseLocationendHouseLocation && f + treeLocation <= endHouseLocation)
    |> Array.length

let countOrangeAndApples startHouseLocationendHouseLocation endHouseLocation appleTreeLocation orangeTreeLocation (apples : int array) (oranges : int array) =
    let countFruitInRange = countFruitInRange startHouseLocationendHouseLocation endHouseLocation
    countFruitInRange appleTreeLocation apples, countFruitInRange orangeTreeLocation oranges


[<Fact>]
let ``HackerRank sample``() =
    let result = countOrangeAndApples 7 11 5 15 [| -2; 2; 1 |] [| 5; -6 |]
    Assert.Equal((1, 1), result)
