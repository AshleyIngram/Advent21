open System.IO

[<EntryPoint>]
let main argv =
    printfn "Running Day 1 Problem 1"

    let result = File.ReadAllLines "input.csv" |> Advent21.Day2.part2
    printfn "Result: %i" result

    0