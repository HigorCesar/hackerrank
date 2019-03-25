// Learn more about F# at http://fsharp.org

open System.IO;
open System

let dayOfProgrammer (year : int) =
    let leapYear = sprintf "12.09.%i" year
    let normalYear = sprintf "13.09.%i" year
    let transitionYear = "26.09.1918"
    if year = 1918 then
        transitionYear
    elif (year % 4) <> 0 then
        normalYear
    elif (year < 1918) then
        leapYear
    elif (year % 400 = 0) || (year % 100 <> 0) then
        leapYear
    else normalYear

[<EntryPoint>]
let main argv =
    let textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true)
    let year = Convert.ToInt32(Console.ReadLine().Trim());
    let result = dayOfProgrammer(year);
    textWriter.WriteLine(result);
    textWriter.Flush();
    textWriter.Close();
    0 // return an integer exit code
