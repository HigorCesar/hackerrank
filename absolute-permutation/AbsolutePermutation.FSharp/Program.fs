module Program = 
    open System
    open System.IO

    let tryFindPos n k v =
        let fstPosI = k + v
        let sndPosI = abs(k - v)
        if fstPosI <= n then Some(fstPosI)
        else if sndPosI > 0 && sndPosI < n then Some(sndPosI)
        else None
    
    let absolutePermutation n k = 
        let tryFindPos = tryFindPos n k
        let permutation = Array.create n -1
        [|1..n|] 
        |> Array.iter(fun v -> 
            match tryFindPos v with
            | Some(idx) -> permutation.[idx - 1] <- v
            | None -> ())
     
        if permutation |> Array.contains -1 then "-1"
         else String.Join(" ",permutation)

    let [<EntryPoint>] main _ = 
        let textWriter = new StreamWriter(Console.OpenStandardOutput());
        let t = Convert.ToInt32(Console.ReadLine());
        for _ in 1 .. t do
            let nk = Console.ReadLine().Split(' ')
            let n = Convert.ToInt32(nk.[0])
            let k = Convert.ToInt32(nk.[1])
            textWriter.WriteLine(absolutePermutation n k)

        textWriter.Flush()
        textWriter.Close()
        0
