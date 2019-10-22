module MergeSortSolution

open System
open Xunit

let split (arr : _ array) =
    let n = arr.Length
    arr.[0..n/2-1], arr.[n/2..n-1]
 
let rec merge (l : 'a array) (r : 'a array) =
    let n = l.Length + r.Length
    let res = Array.zeroCreate<'a> n
    let mutable i, j,inversions = 0, 0, 0
    for k = 0 to n-1 do
        if i >= l.Length   then res.[k] <- r.[j]; j <- j + 1
        elif j >= r.Length then res.[k] <- l.[i]; i <- i + 1
        elif l.[i] < r.[j] then res.[k] <- l.[i]; i <- i + 1
        else
            inversions <- inversions + l.Length - i
            res.[k] <- r.[j]; j <- j + 1

    (res, inversions)

let rec mergeSort arr =
    let mutable inversions = 0
    match arr with
    | [||]  -> ([||],0)
    | [|a|] -> ([|a|],0)
    | arr   -> let (x, y) = split arr
               let leftArray, leftInv = mergeSort x
               let rightArray, rightInv = mergeSort y
               let mergeArray, mergeInv = merge leftArray rightArray
               (mergeArray, leftInv + rightInv + mergeInv)

let LarrysArray (elements : int array) = 
    let inv = mergeSort elements |> snd
    inv |> (fun v -> v % 2 = 0)

[<Fact>]
let ``Sort 3 1 2 Successful``() =
    Assert.Equal<int array>([|1;2;3|], mergeSort [|3;1;2|] |> fst)


[<Fact>]
let ``Sort 1 2 3 already sorted``() =
    Assert.Equal<int array>([|1;2;3|], mergeSort [|1;2;3|] |> fst)    

   
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
    let v1 = mergeSort [|17;21;2;1;16;9;12;11;6;18;20;7;14;8;19;10;3;4;13;5;15|]
    Assert.True(LarrysArray [|17;21;2;1;16;9;12;11;6;18;20;7;14;8;19;10;3;4;13;5;15|])

