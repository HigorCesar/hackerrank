module Calculator
open System
let private cubeArea = 6
let CalculateByCube (surfaceArea: int[,]) row column =
    surfaceArea.[row,column] * cubeArea - 2*(surfaceArea.[row,column]-1)

let neighbors  (surfaceArea: int[,]) row column =
    let neighbor nRow nColumn =
        if nRow < 0 || nRow >= Array2D.length1 surfaceArea ||
           nColumn < 0 ||  nColumn >= Array2D.length2 surfaceArea then
            0
        else
            if surfaceArea.[nRow, nColumn] > surfaceArea.[row, column] then
                surfaceArea.[row, column]
            else
                surfaceArea.[nRow, nColumn]

    neighbor (row - 1) column +
    neighbor (row + 1) column +
    neighbor row (column - 1) +
    neighbor row (column + 1)

let Calculate (surfaceArea: int[,]) row column =
    CalculateByCube surfaceArea row column - neighbors surfaceArea row column

let CalculateWholeCube (surfaceArea: int[,]) =
    [ for y in 0..Array2D.length1 surfaceArea-1 do
        for x in 0..Array2D.length2 surfaceArea-1 do
            yield Calculate surfaceArea y x ]
    |> List.sum


