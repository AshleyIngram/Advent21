module Day2

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Calculates the correct position after navigation`` () =
    seq { "forward 5"; "down 5"; "forward 8"; "up 3"; "down 8"; "forward 2"; } |> Advent21.Day2.part1 |> should equal 150

[<Fact>]
let ``Calculates the correct position with including aim`` () =
    seq { "forward 5"; "down 5"; "forward 8"; "up 3"; "down 8"; "forward 2"; } |> Advent21.Day2.part2 |> should equal 900