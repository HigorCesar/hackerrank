module Tests

open System
open Xunit
open System.Text.RegularExpressions

let LarrysArray2 (a : int array) = 

    match a.Length with
    | 1 -> true
    | 2 -> a.[0]< a.[1]
    | _ ->
        let isOrderable (v : int array) = 
            v.[1] < v.[2] || ( v.[2] < v.[0] &&  v.[1] > v.[0])

        [0..(a.Length / 3) + if a.Length % 3 > 0 then 0 else -1] 
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

let TryFindElementIndexGroup (target : int) (elements: int array) = 
    let element = elements |> Array.tryFindIndex (fun e -> e = target)
    match element with
    | None -> None
    | Some idx ->
        match idx with
        | 0 -> [|idx;idx + 1; idx + 2|] |> Some
        | 1 -> [|idx - 1; idx;idx + 1;|] |> Some
        | x when x >= 2 -> 
            if elements.[idx - 2] = target - 1 && idx < (elements.Length - 1) then
               [|idx - 1; idx;idx + 1;|] |> Some
            else if elements.[idx - 1] = target - 1  && idx < (elements.Length - 2) then
               [|idx; idx + 1;idx + 2;|] |> Some
            else
                [|idx - 2; idx - 1;idx;|] |> Some

let tryToSortGroup (elements : int array) (target: int) = 
    let result = TryFindElementIndexGroup target elements
    match result with
    | None -> false
    | Some group->
        if elements.[group.[1]] > elements.[group.[0]] && elements.[group.[1]] > elements.[group.[2]] && elements.[group.[2]] > elements.[group.[0]] then
            false
        else
            let a =group.[0]
            let b =group.[1]
            let c =group.[2]
            if elements.[b] < elements.[c] then
                let tempA = elements.[a]
                elements.[a] <- elements.[b]
                elements.[b] <- elements.[c]
                elements.[c] <- tempA
                true
            else
                let tempA = elements.[a]
                let tempB = elements.[b]
                elements.[a] <- elements.[c]
                elements.[b] <- tempA
                elements.[c] <- tempB
                true

let LarrysArray (elements : int array) = 
    let lastElement = elements.Length
    let mutable currentElement = 1;
    let mutable  continueTrying = true
    while currentElement < lastElement && continueTrying do
        if elements.[currentElement - 1] = currentElement then
            currentElement <- currentElement + 1
        else
            continueTrying <- tryToSortGroup elements currentElement
    currentElement = lastElement

//[<Fact>]
//let ``TryFindElementIndexGroup first element`` () =
//    let result = TryFindElementIndexGroup 2 [|1;2;3;4|]
//    Assert.Equal<int array>([|1;2;3|],result.Value)

//[<Fact>]
//let ``TryFindElementIndexGroup last element`` () =
//    let result = TryFindElementIndexGroup 4 [|1;2;3;4|]
//    Assert.Equal<int array>([|1;2;3|],result.Value)

//[<Fact>]
//let ``tryToSortGroup success`` () =
//    let elements = [|1;3;4;2|]
//    tryToSortGroup elements 2 |> ignore
//    Assert.Equal<int array>([|1;4;2;3|],elements)



[<Fact>]
let ``1 2 3 is orderable`` () =
    Assert.True(LarrysArray2 [|1;2;3|])

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

