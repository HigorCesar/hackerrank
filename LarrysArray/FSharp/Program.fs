open System.IO
open System
module Program = 

    let LarrysArray (elements : int array) = 
        elements
        |> Seq.mapi(fun idx a -> elements |> Seq.skip (idx + 1) |> Seq.map(fun b -> if a > b then 1 else 0))
        |> Seq.concat
        |> Seq.reduce (fun acc x -> acc + x)
        |> (fun v -> v % 2 = 0)
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

