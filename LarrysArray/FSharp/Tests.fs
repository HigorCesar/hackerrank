module Tests

open System
open Xunit

let LarrysArray (elements : int array) = 
    elements
    |> Seq.mapi(fun idx a -> elements |> Seq.skip (idx + 1) |> Seq.map(fun b -> if a > b then 1 else 0))
    |> Seq.concat
    |> Seq.reduce (fun acc x -> acc + x)
    |> (fun v -> v % 2 = 0)
   
[<Fact>]
let ``1 2 3 is orderable`` () =
    Assert.True(LarrysArray [|1;2;3|])

[<Fact>]
let ``4 3 2 is not orderable`` () =
    Assert.False(LarrysArray [|4;3;2|])

[<Fact>]
let ``1 2 3 5 4 is not orderable`` () =
    Assert.False(LarrysArray [|1;2;3;5;4|])

[<Fact>]
let ``1 3 4 2 is orderable`` () =
    Assert.True(LarrysArray [|1;3;4;2|])

[<Fact>]
let ``1 3 is orderable`` () =
    Assert.True(LarrysArray [|1;3|])

[<Fact>]
let ``4 1 3 2 is orderable`` () =
    Assert.True(LarrysArray [|4;1;3;2|])

[<Fact>]
let ``17 21 2 1 16 9 12 11 6 18 20 7 14 8 19 10 3 4 13 5 15 is orderable`` () =
    Assert.True(LarrysArray [|17;21;2;1;16;9;12;11;6;18;20;7;14;8;19;10;3;4;13;5;15|])

