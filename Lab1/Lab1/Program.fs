open System

open System.Collections.Generic
open Lab1
open State
open Parser

let state, exits = parse Console.ReadLine

let queue = Queue<coordinate>()
for exit in exits do queue.Enqueue exit

let dy = [| 0; 1; 0; -1 |]
let dx = [| -1; 0; 1; 0 |]

let isFree y x =
    y >= 0 && y < state.height
    && x >= 0 && x < state.width
    && state.field[y].[x] <> Wall
    && not state.visited[y].[x]

while queue.Count <> 0 do
    let y, x = queue.Dequeue()
    state.visited[y][x] <- true
    for i = 0 to 3 do
        let y = y + dy[i]
        let x = x + dx[i]
        if isFree y x then
            queue.Enqueue(y, x)

let mutable query = Console.ReadLine()
while query <> null && query <> "" do
    let [| x; y |] = query.Split[| ' ' |] |> Array.map int
    if state.visited[y][x] then
        Console.WriteLine("Can escape!")
    else
        Console.WriteLine("There's no escape :(")
    query <- Console.ReadLine()
