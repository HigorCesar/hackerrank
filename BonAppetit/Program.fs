// Learn more about F# at http://fsharp.org

open System
open System.IO

let bonAppetit (bill : int list) k b =
    let wholeAmount = bill |> List.sum
    let fairAnaAmount = (wholeAmount - bill.[k]) / 2
    b - fairAnaAmount
    
[<EntryPoint>]
let main argv =
    let textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true)
    let nk = Console.ReadLine().Trim()|> (fun text -> text.Split())
    let n = nk.[0] |> Convert.ToInt32
    let k = nk.[1] |> Convert.ToInt32
    let bill = Console.ReadLine().TrimEnd()
               |> (fun text -> text.Split())
               |> Array.map Convert.ToInt32
               |> Array.toList
    let b = Console.ReadLine().Trim() |> Convert.ToInt32
    let result = bonAppetit bill k b
    if result = 0 then
        textWriter.WriteLine("Bon Appetit");
    else
        textWriter.WriteLine(result);
    textWriter.Flush();
    textWriter.Close();
    0 // return an integer exit code