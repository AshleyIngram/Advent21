namespace Advent21

module Day1 =
    let part1 numbers =
        numbers |> Seq.pairwise |> Seq.filter (fun (a, b) -> b > a) |> Seq.toArray |> Array.length
