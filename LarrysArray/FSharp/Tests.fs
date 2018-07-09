module Tests

open System
open Xunit

let LarrysArray (a : int array) = 
    let isOrderable (v : int array) = 
        v.[1] < v.[2] && ( v.[2] < v.[0] ||  v.[1] > v.[0])

    [0..(a.Length / 3) + if a.Length % 3 > 0 then 1 else -1] 
    |> Seq.forall(fun i -> 
        match a |> Array.skip(i * 3) with
        | v when v.Length = 1 -> 
             Array.append [|a.[i * 3 - 2];a.[i * 3 - 1]|] v |> isOrderable
        | v when v.Length = 2 ->
            Array.append [|a.[i * 3 - 1]|] v |> isOrderable
        | v when v.Length > 2 ->
            v |> Array.take 3 |> isOrderable
        | _ -> failwith "non valid case"
    )
    
[<Fact>]
let ``1 2 3 is orderable`` () =
    Assert.True(LarrysArray [|1;2;3|])
 
[<Fact>]
let ``4 3 2 is not orderable`` () =
    Assert.False(LarrysArray [|4;3;2|])

[<Fact>]
let ``1 4 3 2 is not orderable`` () =
    Assert.False(LarrysArray [|1;4;3;2|])

[<Fact>]
let ``1 2 3 5 4 is not orderable`` () =
    Assert.False(LarrysArray [|1;2;3;5;4|])

