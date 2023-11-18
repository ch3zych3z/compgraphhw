module Lab1.Parser

open System
open System.Collections.Generic
open State

let inline private parseCell c =
    match c with
    | ' ' -> Empty
    | '#' -> Wall
    | '$' -> Exit
    | c -> ArgumentException($"Unexpected symbol: {c}") |> raise

let parse (getLine: unit -> string) =
    let exits = List<coordinate>()
    let [| height; width |] = getLine().Split[|' '|] |> Array.map int
    let field = Array.zeroCreate height
    let visited = Array.init height (fun _ -> Array.create width false)
    for i = 0 to height - 1 do
        let str = getLine()
        let fieldRow = Array.zeroCreate width
        for j = 0 to width - 1 do
            fieldRow[j] <- parseCell str[j]
            if fieldRow[j] = Exit then
                exits.Add(i, j)
        field[i] <- fieldRow

    let state = {
        width = width
        height = height
        field = field
        visited = visited
    }
    state, exits
