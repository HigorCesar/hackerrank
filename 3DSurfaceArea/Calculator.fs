module Calculator
open System
let private cubeArea = 6
let CalculateByCube (surfaceArea: int[,]) pos =
    let line,col = pos
    surfaceArea.[line,col] * cubeArea - 2*(surfaceArea.[line,col]-1)

let neighbors  (surfaceArea: int[,]) (pos :int*int) =
    let row,column = pos
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

let Calculate (surfaceArea: int[,]) pos =
    CalculateByCube surfaceArea pos - neighbors surfaceArea pos

let CalculateWholeCube (surfaceArea: int[,]) =
    let mutable wholeValue = 0
    let calc r c v =
        wholeValue <- wholeValue + Calculate surfaceArea (r,c)
    surfaceArea|> Array2D.iteri calc
    wholeValue


