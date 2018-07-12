open System.IO
open System
module Program = 

    let TryFindElementIndexGroup (target : int) (elements: int array) = 
        let element = elements |> Array.tryFindIndex (fun e -> e = target)
        match element with
        | None -> None
        | Some idx ->
            match idx with
            | 0 -> [|idx;idx + 1; idx + 2|] |> Some
            | 1 -> [|idx - 1; idx;idx + 1;|] |> Some
            | x when x >= 2 -> [|idx - 2; idx - 1;idx;|] |> Some

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

    let [<EntryPoint>] main _ =
        //let textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        let textWriter = new StreamWriter(Console.OpenStandardOutput());
        let t = Convert.ToInt32(Console.ReadLine());
        for _ in 0..(t - 1) do
            Console.ReadLine() |> ignore
            Console.ReadLine().Split(' ') 
            |> Array.map(Convert.ToInt32)
            |> LarrysArray
            |> function
                | true -> "YES"
                | false -> "NO"
            |> textWriter.WriteLine

        textWriter.Flush();
        textWriter.Close();
        0

