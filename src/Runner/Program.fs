open System.IO

[<EntryPoint>]
let main argv =
    printfn "Running Day 3 Problem 1"

    let result = File.ReadAllLines "input.csv" |> Advent21.Day3.part1
    printfn "Result: %i" result

    0