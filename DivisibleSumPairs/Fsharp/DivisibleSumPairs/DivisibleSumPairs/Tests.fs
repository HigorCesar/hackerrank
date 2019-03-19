module DivisibleSumPairsTests
open Xunit

let divisibleSumPairs (n : int) (k : int) (ar : int array) =
    ar
    |> Array.mapi (fun index x -> ar |> Array.skip (index + 1) |> Array.map (fun e -> x, e))
    |> Array.concat
    |> Array.filter (fun (a, b) -> (a + b) % k = 0)
    |> Array.length

[<Fact>]
let ``HackerRank example``() =
    let values = [| 1; 3; 2; 6; 1; 2 |]
    Assert.Equal(5, (divisibleSumPairs 6 3 values))
