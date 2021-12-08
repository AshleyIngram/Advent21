open System.IO

let readFileAsNumbers path = 
    File.ReadLines(path) |> Seq.map int

[<EntryPoint>]
let main argv =
    printfn "Running Day 1 Problem 1"

    let result = readFileAsNumbers "input.csv" |> Advent21.Day1.part1
    printfn "Result: %i" result

    0