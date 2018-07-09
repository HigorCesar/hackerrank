open System.IO
open System
open Tests
open Tests
module Program = 

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
    let [<EntryPoint>] main _ =
        let textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        let t = Convert.ToInt32(Console.ReadLine());
        for i in 0..t do
            Console.ReadLine().Split(' ') 
            |> Array.map(Convert.ToInt32)
            |> LarrysArray
            |> textWriter.WriteLine

        textWriter.Flush();
        textWriter.Close();
        0

